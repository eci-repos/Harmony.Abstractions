// /Harmony.Abstractions/Models/Capabilities.cs

// -------------------------------------------------------------------------------------------------
namespace Harmony.Tooling.Models;

public sealed class Capabilities
{
   public required IEnumerable<ToolDescriptor> Tools { get; init; }

   /// <summary>Provider map (e.g., { "mail":"Graph","files":"OneDrive","memory":"Qdrant" }).
   /// </summary>
   public IDictionary<string, string>? Providers { get; init; }
}
