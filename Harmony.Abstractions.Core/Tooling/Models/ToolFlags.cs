using System;

// -----------------------------------------------------------------------------------------------------------------
// This file defines the ToolFlags enum, which is used to specify various characteristics of tools in the Harmony
// framework. Each flag represents a specific property of a tool, such as whether it is deterministic, replayable,
// mutating, requires network access, or requires secrets. The flags can be combined using bitwise operations to
// indicate multiple properties for a single tool.
namespace Harmony.Tooling.Models;

[System.Flags]
public enum ToolFlags
{
   None = 0,
   Deterministic = 1 << 0, // Pure function of inputs (same inputs => same outputs)
   Replayable = 1 << 1, // Artifacts can be cached/reused via cacheKey/inputHash
   Mutating = 1 << 2, // Writes to external systems or side effects
   RequiresNetwork = 1 << 3, // Performs network I/O
   RequiresSecrets = 1 << 4  // Needs secret material/tokens/credentials
}

