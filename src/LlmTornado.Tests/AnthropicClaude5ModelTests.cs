using LlmTornado.Chat.Models;
using LlmTornado.Code.Models;

namespace LlmTornado.Tests;

/// <summary>
/// Registration and capability tests for Claude 5 generation models.
/// </summary>
[TestFixture]
public class AnthropicClaude5ModelTests
{
    [Test]
    public void Fable5_IsDiscoverableOnChatModelAnthropic()
    {
        Assert.That(ChatModel.Anthropic.Claude5.Fable.Name, Is.EqualTo("claude-fable-5"));
        Assert.That(ChatModel.Anthropic.AllModels, Has.Some.Matches<IModel>(m => m.Name == "claude-fable-5"));
    }

    [Test]
    public void Fable51_IsDiscoverableOnChatModelAnthropic()
    {
        Assert.That(ChatModel.Anthropic.Claude5.Fable51.Name, Is.EqualTo("claude-fable-5-1"));
        Assert.That(ChatModel.Anthropic.AllModels, Has.Some.Matches<IModel>(m => m.Name == "claude-fable-5-1"));
    }

    [Test]
    public void Opus5_IsDiscoverableOnChatModelAnthropic()
    {
        Assert.That(ChatModel.Anthropic.Claude5.Opus.Name, Is.EqualTo("claude-opus-5"));
        Assert.That(ChatModel.Anthropic.AllModels, Has.Some.Matches<IModel>(m => m.Name == "claude-opus-5"));
    }

    [Test]
    public void Sonnet5_IsDiscoverableOnChatModelAnthropic()
    {
        Assert.That(ChatModel.Anthropic.Claude5.Sonnet.Name, Is.EqualTo("claude-sonnet-5"));
        Assert.That(ChatModel.Anthropic.AllModels, Has.Some.Matches<IModel>(m => m.Name == "claude-sonnet-5"));
    }

    [Test]
    public void Mythos_IsDiscoverableOnChatModelAnthropic()
    {
        Assert.That(ChatModel.Anthropic.Claude5.Mythos.Name, Is.EqualTo("claude-mythos-5"));
        Assert.That(ChatModel.Anthropic.Claude5.Mythos51.Name, Is.EqualTo("claude-mythos-5-1"));
        Assert.That(ChatModel.Anthropic.OwnsModel("claude-mythos-5"), Is.True);
        Assert.That(ChatModel.Anthropic.OwnsModel("claude-mythos-5-1"), Is.True);
    }

    [Test]
    public void Claude5_OwnsModel_ReturnsTrue()
    {
        Assert.That(ChatModel.Anthropic.OwnsModel("claude-fable-5"), Is.True);
        Assert.That(ChatModel.Anthropic.OwnsModel("claude-fable-5-1"), Is.True);
        Assert.That(ChatModel.Anthropic.OwnsModel("claude-opus-5"), Is.True);
        Assert.That(ChatModel.Anthropic.OwnsModel("claude-sonnet-5"), Is.True);
    }

    [TestCase("claude-fable-5")]
    [TestCase("claude-fable-5-1")]
    [TestCase("claude-mythos-5")]
    [TestCase("claude-mythos-5-1")]
    [TestCase("claude-opus-5")]
    [TestCase("claude-sonnet-5")]
    public void Claude5_IsClaude5Model_Recognized(string modelName)
    {
        Assert.That(ChatModelAnthropicHelper.IsClaude5Model(modelName), Is.True);
        Assert.That(ChatModelAnthropicHelper.IsOpus47OrNewer(modelName), Is.True);
        Assert.That(ChatModelAnthropicHelper.SupportsAdaptiveThinking(modelName), Is.True);
        Assert.That(ChatModelAnthropicHelper.IsEffortCompatibleModel(modelName), Is.True);
        Assert.That(ChatModelAnthropicHelper.RejectsNonDefaultSamplingParams(modelName), Is.True);
        Assert.That(ChatModelAnthropicHelper.RequiresAdaptiveThinkingWhenEnabled(modelName), Is.True);
        Assert.That(ChatModelAnthropicHelper.SupportsHighResVision(modelName), Is.True);
        Assert.That(ChatModelAnthropicHelper.IsThinkingOnByDefault(modelName), Is.True);
    }

    [TestCase("claude-fable-5")]
    [TestCase("claude-fable-5-1")]
    [TestCase("claude-mythos-5")]
    [TestCase("claude-mythos-5-1")]
    public void FableAndMythos_AlwaysOnAdaptiveThinking(string modelName)
    {
        Assert.That(ChatModelAnthropicHelper.IsAlwaysOnAdaptiveThinkingModel(modelName), Is.True);
    }

    [TestCase("claude-opus-5")]
    [TestCase("claude-sonnet-5")]
    public void Opus5AndSonnet5_CanDisableThinking(string modelName)
    {
        Assert.That(ChatModelAnthropicHelper.IsAlwaysOnAdaptiveThinkingModel(modelName), Is.False);
        Assert.That(ChatModelAnthropicHelper.IsThinkingOnByDefault(modelName), Is.True);
    }

    [Test]
    public void Opus5_RestrictsDisabledThinkingToHighEffortOrBelow()
    {
        Assert.That(ChatModelAnthropicHelper.IsOpus5OrNewer("claude-opus-5"), Is.True);
        Assert.That(ChatModelAnthropicHelper.RestrictsDisabledThinkingToHighEffortOrBelow("claude-opus-5"), Is.True);
        Assert.That(ChatModelAnthropicHelper.RestrictsDisabledThinkingToHighEffortOrBelow("claude-sonnet-5"), Is.False);
        Assert.That(ChatModelAnthropicHelper.RestrictsDisabledThinkingToHighEffortOrBelow("claude-opus-4-8"), Is.False);
    }

    [TestCase("claude-fable-5-1")]
    [TestCase("claude-mythos-5-1")]
    public void Fable51_RejectsForcedToolChoice(string modelName)
    {
        Assert.That(ChatModelAnthropicHelper.RejectsForcedToolChoice(modelName), Is.True);
        Assert.That(ChatModelAnthropicHelper.IsFable51OrNewer(modelName), Is.True);
    }

    [TestCase("claude-fable-5")]
    [TestCase("claude-opus-5")]
    [TestCase("claude-sonnet-5")]
    public void EarlierClaude5_AllowsForcedToolChoice(string modelName)
    {
        Assert.That(ChatModelAnthropicHelper.RejectsForcedToolChoice(modelName), Is.False);
    }

    [Test]
    public void Claude5_ContextWindow_IsOneMillionTokens()
    {
        Assert.That(ChatModel.Anthropic.Claude5.Fable.ContextTokens, Is.EqualTo(1_000_000));
        Assert.That(ChatModel.Anthropic.Claude5.Fable51.ContextTokens, Is.EqualTo(1_000_000));
        Assert.That(ChatModel.Anthropic.Claude5.Opus.ContextTokens, Is.EqualTo(1_000_000));
        Assert.That(ChatModel.Anthropic.Claude5.Sonnet.ContextTokens, Is.EqualTo(1_000_000));
        Assert.That(ChatModel.Anthropic.Claude5.Mythos.ContextTokens, Is.EqualTo(1_000_000));
        Assert.That(ChatModel.Anthropic.Claude5.Mythos51.ContextTokens, Is.EqualTo(1_000_000));
    }
}
