using LlmTornado.Embedding;
using LlmTornado.Embedding.Models;
using LlmTornado.Rerank.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LlmTornado.Tests;

[TestFixture]
public class VoyageModelTests
{
    [Test]
    public void Gen4_TextModels_AreDiscoverable()
    {
        Assert.That(EmbeddingModel.Voyage.Gen4.Large.Name, Is.EqualTo("voyage-4-large"));
        Assert.That(EmbeddingModel.Voyage.Gen4.Standard.Name, Is.EqualTo("voyage-4"));
        Assert.That(EmbeddingModel.Voyage.Gen4.Lite.Name, Is.EqualTo("voyage-4-lite"));
        Assert.That(EmbeddingModel.Voyage.Gen4.Nano.Name, Is.EqualTo("voyage-4-nano"));
        Assert.That(EmbeddingModel.Voyage.Gen4.Code.Name, Is.EqualTo("voyage-code-4"));
        Assert.That(EmbeddingModel.Voyage.OwnsModel("voyage-code-4"), Is.True);
        Assert.That(EmbeddingModel.Voyage.OwnsModel("voyage-4-large"), Is.True);
    }

    [Test]
    public void Gen4_DefaultDimensions_Are1024()
    {
        Assert.That(EmbeddingModel.Voyage.Gen4.Large.OutputDimensions, Is.EqualTo(1024));
        Assert.That(EmbeddingModel.Voyage.Gen4.Lite.OutputDimensions, Is.EqualTo(1024));
        Assert.That(EmbeddingModel.Voyage.Gen4.Nano.OutputDimensions, Is.EqualTo(1024));
        Assert.That(EmbeddingModel.Voyage.Gen4.Code.OutputDimensions, Is.EqualTo(1024));
    }

    [Test]
    public void DomainModels_AreDiscoverable()
    {
        Assert.That(EmbeddingModel.Voyage.Gen2.Finance.Name, Is.EqualTo("voyage-finance-2"));
        Assert.That(EmbeddingModel.Voyage.Gen2.Law.Name, Is.EqualTo("voyage-law-2"));
        Assert.That(EmbeddingModel.Voyage.Gen2.Multilingual.Name, Is.EqualTo("voyage-multilingual-2"));
        Assert.That(EmbeddingModel.Voyage.OwnsModel("voyage-finance-2"), Is.True);
        Assert.That(EmbeddingModel.Voyage.OwnsModel("voyage-law-2"), Is.True);
    }

    [Test]
    public void Context4_IsDiscoverable()
    {
        Assert.That(ContextualEmbeddingModel.Voyage.Gen4.Context4.Name, Is.EqualTo("voyage-context-4"));
        Assert.That(ContextualEmbeddingModel.Voyage.OwnsModel("voyage-context-4"), Is.True);
        Assert.That(ContextualEmbeddingModel.Voyage.Gen4.Context4.ContextTokens, Is.EqualTo(120_000));
    }

    [Test]
    public void Rerank3_IsDiscoverable()
    {
        Assert.That(RerankModel.Voyage.Gen3.Rerank3.Name, Is.EqualTo("rerank-3"));
        Assert.That(RerankModel.Voyage.Gen3.Rerank3Lite.Name, Is.EqualTo("rerank-3-lite"));
        Assert.That(RerankModel.Voyage.Gen2.Default.Name, Is.EqualTo("rerank-2"));
        Assert.That(RerankModel.Voyage.OwnsModel("rerank-3"), Is.True);
        Assert.That(RerankModel.Voyage.OwnsModel("rerank-2"), Is.True);
    }

    [Test]
    public void Multimodal35_HasMatryoshkaDimensions()
    {
        Assert.That(MultimodalEmbeddingModel.Voyage.Gen35.Multimodal.Name, Is.EqualTo("voyage-multimodal-3.5"));
        Assert.That(MultimodalEmbeddingModel.Voyage.Gen35.Multimodal.MatryoshkaDimensions, Is.EqualTo(new[] { 256, 512, 1024, 2048 }));
    }

    [Test]
    public void AutoChunkingRequest_SerializesFlatDocuments()
    {
        ContextualEmbeddingRequest request = new ContextualEmbeddingRequest(ContextualEmbeddingModel.Voyage.Gen4.Context4,
        [
            "first document",
            "second document"
        ])
        {
            InputType = ContextualEmbeddingInputType.Document,
            EnableAutoChunking = true,
            ChunkSize = 512,
            ChunkOverlap = 0
        };

        JObject json = JObject.Parse(JsonConvert.SerializeObject(request, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));

        Assert.That(json["inputs"]!.Type, Is.EqualTo(JTokenType.Array));
        Assert.That(json["inputs"]![0]!.Type, Is.EqualTo(JTokenType.String));
        Assert.That(json["inputs"]![0]!.Value<string>(), Is.EqualTo("first document"));
        Assert.That(json["enable_auto_chunking"]!.Value<bool>(), Is.True);
        Assert.That(json["chunk_size"]!.Value<int>(), Is.EqualTo(512));
        Assert.That(json["chunk_overlap"]!.Value<int>(), Is.EqualTo(0));
        Assert.That(json["model"]!.Value<string>(), Is.EqualTo("voyage-context-4"));
    }

    [Test]
    public void PreChunkedRequest_StillSerializesNestedInputs()
    {
        ContextualEmbeddingRequest request = new ContextualEmbeddingRequest(ContextualEmbeddingModel.Voyage.Gen3.Context3,
        [
            ["doc_1_chunk_1", "doc_1_chunk_2"]
        ]);

        JObject json = JObject.Parse(JsonConvert.SerializeObject(request, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));

        Assert.That(json["inputs"]![0]!.Type, Is.EqualTo(JTokenType.Array));
        Assert.That(json["inputs"]![0]![0]!.Value<string>(), Is.EqualTo("doc_1_chunk_1"));
        Assert.That(json["enable_auto_chunking"], Is.Null);
    }
}
