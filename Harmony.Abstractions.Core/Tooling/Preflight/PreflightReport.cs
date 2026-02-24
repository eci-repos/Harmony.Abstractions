// /Harmony.Abstractions/Models/PreflightReport.cs

// -------------------------------------------------------------------------------------------------
namespace Harmony.Tooling.Preflight;

public sealed class PreflightReport
{
   public const string DefaultPreflightMode = "strict";
   public const string ReplayAllowedPreflightMode = "replay-allowed";

   public required IReadOnlyList<string> RequiredTools { get; init; }
   public required IReadOnlyList<string> Available { get; init; }
   public required IReadOnlyList<string> Missing { get; init; }

   public bool IsSuccessful => Missing.Count == 0;

   /// <summary>"strict" | "replay-allowed"</summary>
   public required string Mode { get; init; } = DefaultPreflightMode;
}
