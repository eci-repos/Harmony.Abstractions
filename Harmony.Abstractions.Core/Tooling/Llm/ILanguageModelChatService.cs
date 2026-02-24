
// /Harmony.Abstractions/Harmony.Tooling/Llm/ILanguageModelChatService.cs

// -------------------------------------------------------------------------------------------------
namespace Harmony.Tooling.Llm;

public interface ILanguageModelChatService
{
   Task<string> GetAssistantReplyAsync(ChatTranscript transcript, CancellationToken ct = default);
   Task<string> GetAssistantReplyAsync(
      ChatTranscript transcript, Func<ChatMessage, bool>? modelFilter, 
      CancellationToken ct = default);
}

