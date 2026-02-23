
// /Harmony.Abstractions/Models/PreflightReport.cs

// -------------------------------------------------------------------------------------------------
namespace Harmony.Abstractions.Models;

public sealed class PreflightReport
{
   public required IReadOnlyList<string> RequiredTools { get; init; }
   public required IReadOnlyList<string> Available { get; init; }
   public required IReadOnlyList<string> Missing { get; init; }
   /// <summary>"strict" | "replay-allowed"</summary>
   public required string Mode { get; init; }
}
