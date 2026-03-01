
// /Harmony.Abstractions/Harmony.Tooling/Llm/ILanguageModelChatService.cs

// -------------------------------------------------------------------------------------------------
namespace Harmony.Tooling.Llm;

/// <summary>
/// Interface for a service that interacts with a language model to generate assistant replies
/// based on a chat transcript. 
/// </summary>
public interface ILanguageModelChatService
{
   Task<string> GetAssistantReplyAsync(ChatTranscript transcript, CancellationToken ct = default);

   Task<string> GetAssistantReplyAsync(
      ChatTranscript transcript, Func<ChatMessage, bool>? modelFilter, 
      CancellationToken ct = default);
}

