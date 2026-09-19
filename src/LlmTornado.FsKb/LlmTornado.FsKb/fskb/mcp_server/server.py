"""
MCP (Model Context Protocol) server implementation.
Exposes tools and resources for semantic search.
"""

from __future__ import annotations

import json
from pathlib import Path
from typing import Any

from loguru import logger

try:
    from mcp.server import Server, ServerRequestContext
    from mcp.server.stdio import stdio_server
    from mcp.types import (
        CallToolRequestParams,
        CallToolResult,
        ListResourcesResult,
        ListToolsResult,
        PaginatedRequestParams,
        ReadResourceRequestParams,
        ReadResourceResult,
        Resource,
        TextContent,
        TextResourceContents,
        Tool,
    )
    MCP_AVAILABLE = True
except ImportError:
    MCP_AVAILABLE = False
    logger.error("mcp package not installed, MCP server unavailable")

from ..config import Settings
from ..indexing import IndexingEngine
from ..search import QueryEngine


class MCPServer:
    """MCP server for FSKB semantic search."""

    def __init__(
        self,
        settings: Settings,
        indexing_engine: IndexingEngine,
        query_engine: QueryEngine,
    ):
        if not MCP_AVAILABLE:
            raise RuntimeError("mcp package not installed")

        self.settings = settings
        self.indexing_engine = indexing_engine
        self.query_engine = query_engine

        self.server = Server(
            "fskb-server",
            on_list_tools=self._on_list_tools,
            on_call_tool=self._on_call_tool,
            on_list_resources=self._on_list_resources,
            on_read_resource=self._on_read_resource,
        )

        logger.info("MCP server initialized")

    async def _on_list_tools(
        self,
        ctx: ServerRequestContext,
        params: PaginatedRequestParams | None,
    ) -> ListToolsResult:
        return ListToolsResult(tools=self._tools())

    def _tools(self) -> list[Tool]:
        return [
            Tool(
                name="add_root",
                description="Add a root directory to index for semantic search",
                input_schema={
                    "type": "object",
                    "properties": {
                        "path": {
                            "type": "string",
                            "description": "Absolute path to the root directory"
                        }
                    },
                    "required": ["path"]
                }
            ),
            Tool(
                name="remove_root",
                description="Remove a root directory from indexing",
                input_schema={
                    "type": "object",
                    "properties": {
                        "path": {
                            "type": "string",
                            "description": "Absolute path to the root directory"
                        }
                    },
                    "required": ["path"]
                }
            ),
            Tool(
                name="search",
                description="Search for code or text semantically across indexed files",
                input_schema={
                    "type": "object",
                    "properties": {
                        "query": {
                            "type": "string",
                            "description": "Search query describing what to find"
                        },
                        "root_path": {
                            "type": "string",
                            "description": "Root directory to search in"
                        },
                        "branch": {
                            "type": "string",
                            "description": "Git branch to search (optional, defaults to current)"
                        },
                        "top_k": {
                            "type": "integer",
                            "description": "Number of results to return (default 10)"
                        }
                    },
                    "required": ["query", "root_path"]
                }
            ),
            Tool(
                name="get_status",
                description="Get indexing status and statistics",
                input_schema={
                    "type": "object",
                    "properties": {
                        "root_path": {
                            "type": "string",
                            "description": "Optional root path to get specific stats"
                        }
                    }
                }
            ),
            Tool(
                name="list_roots",
                description="List all indexed root directories",
                input_schema={
                    "type": "object",
                    "properties": {}
                }
            ),
        ]

    async def _on_call_tool(
        self,
        ctx: ServerRequestContext,
        params: CallToolRequestParams,
    ) -> CallToolResult:
        arguments = params.arguments or {}
        name = params.name

        try:
            if name == "add_root":
                return await self._handle_add_root(arguments)
            if name == "remove_root":
                return await self._handle_remove_root(arguments)
            if name == "search":
                return await self._handle_search(arguments)
            if name == "get_status":
                return await self._handle_get_status(arguments)
            if name == "list_roots":
                return await self._handle_list_roots(arguments)
            return self._text_result(f"Unknown tool: {name}", is_error=True)
        except Exception as e:
            logger.error(f"Error handling tool {name}: {e}")
            return self._text_result(f"Error: {str(e)}", is_error=True)

    async def _on_list_resources(
        self,
        ctx: ServerRequestContext,
        params: PaginatedRequestParams | None,
    ) -> ListResourcesResult:
        resources: list[Resource] = []

        for root_path in self.indexing_engine.roots.keys():
            root_state = self.indexing_engine.roots[root_path]

            resources.append(Resource(
                uri=f"fskb://{root_path}/stats",
                name=f"Stats for {root_path}",
                mime_type="application/json",
                description=f"Indexing statistics for {root_path}",
            ))
            resources.append(Resource(
                uri=f"fskb://{root_path}/branch/{root_state.current_branch}",
                name=f"Branch {root_state.current_branch}",
                mime_type="text/plain",
                description=f"Current branch for {root_path}",
            ))

        return ListResourcesResult(resources=resources)

    async def _on_read_resource(
        self,
        ctx: ServerRequestContext,
        params: ReadResourceRequestParams,
    ) -> ReadResourceResult:
        uri = str(params.uri)
        text, mime_type = self._read_resource_text(uri)
        return ReadResourceResult(
            contents=[
                TextResourceContents(uri=uri, text=text, mime_type=mime_type)
            ]
        )

    def _read_resource_text(self, uri: str) -> tuple[str, str]:
        if not uri.startswith("fskb://"):
            raise ValueError(f"Invalid URI: {uri}")

        parts = uri[7:].split("/")
        if len(parts) < 2:
            raise ValueError(f"Invalid URI format: {uri}")

        root_path = Path(parts[0])
        resource_type = parts[1]

        if resource_type == "stats":
            stats = self.indexing_engine.get_stats(root_path)
            return json.dumps(stats, indent=2), "application/json"

        if resource_type == "branch" and len(parts) > 2:
            root_state = self.indexing_engine.roots.get(root_path)
            if root_state:
                return f"Current branch: {root_state.current_branch}", "text/plain"
            return "Root not found", "text/plain"

        raise ValueError(f"Unknown resource type: {resource_type}")

    @staticmethod
    def _text_result(text: str, is_error: bool = False) -> CallToolResult:
        return CallToolResult(
            content=[TextContent(type="text", text=text)],
            is_error=is_error,
        )

    async def _handle_add_root(self, arguments: dict[str, Any]) -> CallToolResult:
        path = arguments.get("path")
        if not path:
            return self._text_result("Error: path argument required", is_error=True)

        root_path = Path(path)
        success = await self.indexing_engine.add_root(root_path)

        if success:
            return self._text_result(
                f"Successfully added root: {root_path}\nIndexing will begin shortly."
            )
        return self._text_result(f"Failed to add root: {root_path}", is_error=True)

    async def _handle_remove_root(self, arguments: dict[str, Any]) -> CallToolResult:
        path = arguments.get("path")
        if not path:
            return self._text_result("Error: path argument required", is_error=True)

        root_path = Path(path)
        success = await self.indexing_engine.remove_root(root_path)

        if success:
            return self._text_result(f"Successfully removed root: {root_path}")
        return self._text_result(f"Failed to remove root: {root_path}", is_error=True)

    async def _handle_search(self, arguments: dict[str, Any]) -> CallToolResult:
        query = arguments.get("query")
        root_path_str = arguments.get("root_path")
        branch = arguments.get("branch")
        top_k = arguments.get("top_k", 10)

        if not query:
            return self._text_result("Error: query argument required", is_error=True)
        if not root_path_str:
            return self._text_result("Error: root_path argument required", is_error=True)

        root_path = Path(root_path_str)

        if not branch:
            root_state = self.indexing_engine.roots.get(root_path)
            if not root_state:
                return self._text_result(f"Error: root not found: {root_path}", is_error=True)
            branch = root_state.current_branch

        results = await self.query_engine.search(
            query=query,
            root_path=root_path,
            branch_name=branch,
            top_k=top_k,
        )

        if not results:
            return self._text_result(f"No results found for query: {query}")

        output_lines = [f"Found {len(results)} results for: {query}\n"]

        for i, result in enumerate(results, 1):
            output_lines.append(f"\n{i}. {result.file_path} (lines {result.line_start}-{result.line_end}) [score: {result.score:.3f}]")
            output_lines.append(f"   {result.content[:200]}..." if len(result.content) > 200 else f"   {result.content}")

        return self._text_result("\n".join(output_lines))

    async def _handle_get_status(self, arguments: dict[str, Any]) -> CallToolResult:
        root_path_str = arguments.get("root_path")

        if root_path_str:
            stats = self.indexing_engine.get_stats(Path(root_path_str))
        else:
            stats = self.indexing_engine.get_stats()

        return self._text_result(f"Indexing Status:\n{json.dumps(stats, indent=2)}")

    async def _handle_list_roots(self, arguments: dict[str, Any]) -> CallToolResult:
        roots = list(self.indexing_engine.roots.keys())

        if not roots:
            return self._text_result("No roots currently indexed.")

        output_lines = ["Indexed roots:"]
        for root in roots:
            root_state = self.indexing_engine.roots[root]
            output_lines.append(f"  - {root} (branch: {root_state.current_branch})")

        return self._text_result("\n".join(output_lines))

    async def run(self):
        """Run the MCP server (stdio mode)."""
        logger.info("Starting MCP server (stdio mode)")

        async with stdio_server() as (read_stream, write_stream):
            await self.server.run(
                read_stream,
                write_stream,
                self.server.create_initialization_options()
            )
