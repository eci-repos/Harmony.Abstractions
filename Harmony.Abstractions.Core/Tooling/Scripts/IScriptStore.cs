// /Harmony.Abstractions/Harmony.Tooling/Scripts/IScriptStore.cs

// -------------------------------------------------------------------------------------------------
namespace Harmony.Tooling.Scripts;


/// <summary>
/// Stores immutable HRF envelopes (scripts) by id.
/// Harmony.Format remains independent of MCP/SemanticKernel; this is a pure persistence contract.
/// </summary>
public interface IScriptStore
{
   /// <summary>
   /// Register (or replace) an envelope under the given script id.
   /// Implementations may choose to validate before storing.
   /// </summary>
   Task RegisterAsync<T>(
      string scriptId,
      T envelope,
      CancellationToken ct = default);

   /// <summary>
   /// Get an envelope by id; returns null if not found.
   /// </summary>
   Task<T?> GetAsync<T>(
      string scriptId,
      CancellationToken ct = default);

   /// <summary>
   /// List registered script ids (optionally include metadata in the future).
   /// </summary>
   Task<IReadOnlyList<string>> ListAsync(
      CancellationToken ct = default);

   /// <summary>
   /// Delete a script by id. Returns true if removed; false if not found.
   /// </summary>
   Task<bool> DeleteAsync(
      string scriptId,
      CancellationToken ct = default);

   /// <summary>
   /// Returns true if a script id exists.
   /// </summary>
   Task<bool> ExistsAsync(
      string scriptId,
      CancellationToken ct = default);
}
