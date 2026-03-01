
// /Harmony.Abstractions/Harmony.Tooling/Llm/ChatTranscript.cs

// -------------------------------------------------------------------------------------------------
namespace Harmony.Tooling.Llm;

/// <summary>
/// ChatTranscript represents a sequence of chat messages exchanged between a user and an AI
/// assistant. It serves as a record of the conversation, allowing for context retention and 
/// continuity in interactions with the AI. Each message in the transcript includes information 
/// about the sender (user or assistant) and the content of the message, enabling the AI to 
/// understand the flow of the conversation and respond appropriately. 
/// </summary>
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
