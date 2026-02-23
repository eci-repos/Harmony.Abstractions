// /Harmony.Abstractions/Contracts/IRedactor.cs
using System.Text.Json;

// -------------------------------------------------------------------------------------------------
namespace Harmony.Abstractions.Contracts;

/// <summary>
/// Redacts sensitive content before it reaches history/artifacts.
/// Hosts decide policies; tools/hosts call this on inputs/outputs where needed.
/// </summary>
public interface IRedactor
{
   JsonElement RedactInputs(string toolName, JsonElement inputs);
   JsonElement RedactOutputs(string toolName, JsonElement outputs);
}
