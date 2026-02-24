
// /Harmony.Abstractions/Harmony.Tooling/Llm/ChatTranscript.cs

// -------------------------------------------------------------------------------------------------
namespace Harmony.Tooling.Llm;

public sealed class ChatTranscript
{
   public IList<ChatMessage> Messages { get; init; } = new List<ChatMessage>();
   public ChatTranscript(IList<ChatMessage> messages)
   {
      Messages = messages;
   }
   public ChatTranscript()
   {
   }
}
