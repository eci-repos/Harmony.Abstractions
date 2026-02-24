// /Harmony.Abstractions/Models/ToolError.cs
using System.Text.Json;

// -------------------------------------------------------------------------------------------------
namespace Harmony.Tooling.Models;

public sealed class ToolError
{
   public required string Code { get; init; }  // e.g., "ValidationError", "Timeout", "Unauthorized"
   public required string Message { get; init; }
   public JsonElement? Details { get; init; }
}
