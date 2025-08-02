﻿using LlmTornado.Agents;
using LlmTornado.Agents.AgentStates;
using LlmTornado.Chat.Models;
using Lombda.StateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LlmTornado.Demo
{
    public class AgentStateMachineDemo : DemoBase
    {
        [TornadoTest]
        public async Task BasicTestStreaming()
        {
            // Create an instance of the BasicLombdaAgent
            BasicLombdaAgent agent = new BasicLombdaAgent();
            agent.RootStreamingEvent += ReceiveStream; // Subscribe to the streaming event
            // Example task to run through the state machine

            string task = "What is the capital of France?";
            Console.WriteLine($"[User]: {task}");
            Console.Write("[Agent]: ");
            // Run the state machine and get the result
            var result = await agent.AddToConversation(task, streaming: true);
            // Output the result
            Console.Write("\n");
        }

        [TornadoTest]
        public async Task BasicTest()
        {
            // Create an instance of the BasicLombdaAgent
            BasicLombdaAgent agent = new BasicLombdaAgent();
            agent.RootStreamingEvent += ReceiveStream; // Subscribe to the streaming event
            // Example task to run through the state machine

            string task = "What is the capital of France?";
            Console.WriteLine($"[User]: {task}");
            Console.Write("[Agent]: ");
            // Run the state machine and get the result
            var result = await agent.AddToConversation(task, streaming: false);
            // Output the result
            Console.Write("\n");
        }

        [TornadoTest]
        public async Task BasicImageTestStreaming()
        {
            // Create an instance of the BasicLombdaAgent
            BasicLombdaAgent agent = new BasicLombdaAgent();
            agent.RootStreamingEvent += ReceiveStream; // Subscribe to the streaming event
            // Example task to run through the state machine

            string task = "What is in image?";
            Console.WriteLine($"[User]: {task}");
            Console.Write("[Agent]: ");
            // Run the state machine and get the result
            //Preprocessor cannot handle image input
            var result = await agent.AddImageToConversation(task, "C:\\Users\\johnl\\Pictures\\dogs cropped.jpg", streaming: true);
            // Output the result
            Console.Write("\n");
        }

        public async Task ReceiveStream(ModelStreamingEvents stream)
        {
            Console.Write($"{stream.EventType}");
        }
    }

    public class BasicLombdaAgent : ControllerAgent
    {
        /// <summary>
        /// Setup the input preprocessor to run the state machine
        /// </summary>
        public ResearchAgent _stateMachine { get; set; }

        public BasicLombdaAgent() : base("basic")
        {             //Initialize the state machine
            _stateMachine = new ResearchAgent(this);
            InputPreprocessor = RunStateMachine;
        }

        public override void InitializeAgent()
        {

            string instructions = $"""You are a person assistant who will receive information preprocessed by a Agentic system to help answer the question. Use SYSTEM message from before the user input as tool output""";
            ControlAgent = new TornadoAgent(Program.Connect(), ChatModel.OpenAi.Gpt41.V41, instructions);
        }

        public async Task<string> RunStateMachine(string task)
        {
            //Return the final result
            var result = (await _stateMachine.Run(task))[0].FinalReport ?? task;
            return result.ToString() ?? task;
        }
    }

    public class ResearchAgent : AgentStateMachine<string, ReportData>
        {
            public ResearchAgent(ControllerAgent lombdaAgent) : base(lombdaAgent) { }

            public override void InitilizeStates()
            {
                //Setup states
                PlanningState plannerState = new PlanningState(this); //custom init so you can add input here
                ResearchState ResearchState = new ResearchState(this);
                ReportingState reportingState = new ReportingState(this);

                //Setup Transitions between states
                plannerState.AddTransition((result) => result.items.Length > 0, ResearchState); //Check if a plan was generated or Rerun
                ResearchState.AddTransition(reportingState); //Use Lambda expression For passthrough to reporting state
                reportingState.AddTransition(new ExitState()); //Use Lambda expression For passthrough to Exit

                //Create State Machine Runner with String as input and ReportData as output
                SetEntryState(plannerState);
                SetOutputState(reportingState);
            }
        }
       

        class PlanningState : AgentState<string, WebSearchPlan>
        {
            public PlanningState(StateMachine stateMachine) : base(stateMachine) { }

            public override TornadoAgent InitilizeStateAgent()
            {
                return new TornadoAgent(
                    client: Program.Connect(),
                    model: ChatModel.OpenAi.Gpt41.V41Mini,
                    instructions: """
                    You are a helpful research assistant. Given a query, come up with a set of web searches, 
                    to perform to best answer the query. Output between 5 and 20 terms to query for. 
                    """,
                    outputSchema: typeof(WebSearchPlan));
            }

            public override async Task<WebSearchPlan> Invoke(string input)
            {
                return await BeginRunnerAsync<WebSearchPlan>(input);
            }
        }

        class ReportingState : AgentState<string, ReportData>
        {
            public ReportingState(StateMachine stateMachine) : base(stateMachine) { }

            public override TornadoAgent InitilizeStateAgent()
            {
                return new TornadoAgent(
                    Program.Connect(),
                    ChatModel.OpenAi.Gpt41.V41Mini,
                    instructions: """
                    You are a senior researcher tasked with writing a cohesive report for a research query.
                    you will be provided with the original query, and some initial research done by a research assistant.

                    you should first come up with an outline for the report that describes the structure and flow of the report. 
                    Then, generate the report and return that as your final output.

                    The final output should be in markdown format, and it should be lengthy and detailed. Aim for 5-10 pages of content, at least 1000 words.
                    """,
                    outputSchema: typeof(ReportData)
                    );
            }

            public override async Task<ReportData> Invoke(string input)
            {
                return await BeginRunnerAsync<ReportData>(input);
            }
        }

        class ResearchState : AgentState<WebSearchPlan, string>
        {
            public ResearchState(StateMachine stateMachine) : base(stateMachine) { }
            public override TornadoAgent InitilizeStateAgent()
            {
                return new TornadoAgent(
                client: Program.Connect(),
                model: ChatModel.OpenAi.Gpt41.V41Mini,
                instructions: """
                    You are a research assistant. Given a search term, you search the web for that term and
                    produce a concise summary of the results. The summary must be 2-3 paragraphs and less than 300 
                    words. Capture the main points. Write succinctly, no need to have complete sentences or good
                    grammar. This will be consumed by someone synthesizing a report, so its vital you capture the 
                    essence and ignore any fluff. Do not include any additional commentary other than the summary itself.
                    """
                );
            }

            public override async Task<string> Invoke(WebSearchPlan plan)
            {
                return await InvokeThreaded(plan);
            }

            public async Task<string> InvokeThreaded(WebSearchPlan plan)
            {
                List<Task<string>> researchTask = new();
                plan.items.ToList()
                    .ForEach(item =>
                        researchTask.Add(Task.Run(async () => await RunResearchAgent(item))));
                string[] researchResults = await Task.WhenAll(researchTask);
                return string.Join("[RESEARCH RESULT]\n\n\n", researchResults);
            }

            public async Task<string> RunResearchAgent(WebSearchItem item)
            {
                return (await BeginRunnerAsync(InitilizeStateAgent(), item.query)).Messages.Last().Content ?? "";
            }
        }

        public struct WebSearchPlan
        {
            public WebSearchItem[] items { get; set; }
            public WebSearchPlan(WebSearchItem[] items)
            {
                this.items = items;
            }
        }

        public struct WebSearchItem
        {
            public string reason { get; set; }
            public string query { get; set; }

            public WebSearchItem(string reason, string query)
            {
                this.reason = reason;
                this.query = query;
            }
        }

        public struct ReportData
        {
            public string ShortSummary { get; set; }
            public string FinalReport { get; set; }
            public string[] FollowUpQuestions { get; set; }
            public ReportData(string shortSummary, string finalReport, string[] followUpQuestions)
            {
                this.ShortSummary = shortSummary;
                this.FinalReport = finalReport;
                this.FollowUpQuestions = followUpQuestions;
            }
        }
}
