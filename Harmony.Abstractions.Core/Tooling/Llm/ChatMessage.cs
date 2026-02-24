using System;
using System.Collections.Generic;
using System.Text;

// ------------------------------------------------------------------------------------------------- 
namespace Harmony.Tooling.Llm;

/// <summary>
/// A single chat message with optional HRF metadata.
/// This enables ChatConversation to preserve HRF semantics (channel/recipient/termination)
/// without coupling Harmony.Format to any provider.
/// </summary>
public sealed class ChatMessage
{
   public ChatMessage(
      string role,                 // "system" | "user" | "assistant" | "tool"
      string content,
      string? name = null,
      string? channel = null,
      string? contentType = null,  // "text", "json", etc.
      string? recipient = null,
      string? termination = null,
      int? sourceIndex = null)
   {
      Role = role ?? throw new ArgumentNullException(nameof(role));
      Content = content ?? string.Empty;
      Name = name ?? String.Empty;

      Channel = channel;
      ContentType = contentType;
      Recipient = recipient;
      Termination = termination;

      SourceIndex = sourceIndex;
      Timestamp = DateTimeOffset.UtcNow;
   }

   public string Role { get; }
   public string Content { get; }
   public string? Name { get; init; }

   public string? Channel { get; }
   public string? ContentType { get; }
   public string? Recipient { get; }
   public string? Termination { get; }

   public int? SourceIndex { get; }
   public DateTimeOffset Timestamp { get; }
}
