
// /Harmony.Abstractions/Harmony.Tooling/Helpers/ToolArgs.cs
using System.Text.Json;

// -------------------------------------------------------------------------------------------------
namespace Harmony.Tooling.Helpers;

public static class ToolArgs
{
   public static JsonDocument FromObject(object? value) =>
       JsonDocument.Parse(System.Text.Json.JsonSerializer.Serialize(value));

   public static JsonDocument FromDictionary(IReadOnlyDictionary<string, object?> args) =>
       JsonDocument.Parse(System.Text.Json.JsonSerializer.Serialize(args));
}
