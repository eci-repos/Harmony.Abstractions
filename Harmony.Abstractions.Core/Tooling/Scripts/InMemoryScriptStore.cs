using System.Collections.Concurrent;
using System.Text.Json;

// -------------------------------------------------------------------------------------------------
namespace Harmony.Tooling.Scripts;

/// <summary>
/// Default in-memory implementation of IScriptStore.
/// Intended for development, testing, and single-process scenarios.
/// Thread-safe via ConcurrentDictionary.
/// </summary>
public sealed class InMemoryScriptStore : IScriptStore
{
   private readonly ConcurrentDictionary<string, object> _scripts =
       new(StringComparer.OrdinalIgnoreCase);

   public Task RegisterAsync<T>(
       string scriptId,
       T envelope,
       CancellationToken ct = default)
   {
      if (string.IsNullOrWhiteSpace(scriptId))
         throw new ArgumentException("scriptId must be provided.", nameof(scriptId));
      if (envelope is null)
         throw new ArgumentNullException(nameof(envelope));
      ct.ThrowIfCancellationRequested();

      // Immutability guaranted, and ensure T is serializable via System.Text.Json.
      var stored = DeepClone(envelope)!;
      _scripts[scriptId] = stored;

      //_scripts[scriptId] = envelope!;
      return Task.CompletedTask;
   }

   public Task<T?> GetAsync<T>(
       string scriptId,
       CancellationToken ct = default)
   {
      if (string.IsNullOrWhiteSpace(scriptId))
         throw new ArgumentException("scriptId must be provided.", nameof(scriptId));
      ct.ThrowIfCancellationRequested();

      if (!_scripts.TryGetValue(scriptId, out var obj))
         return Task.FromResult<T?>(default);

      // If types don’t match (e.g., caller asks for a different T than what was stored),
      // return default to honor the interface contract.
      if (obj is not T typed)
         return Task.FromResult<T?>(default);

      // For immutability by copy, uncomment:
      var clone = DeepClone(typed);
      return Task.FromResult(clone);

      //return Task.FromResult<T?>(typed);
   }

   public Task<IReadOnlyList<string>> ListAsync(
       CancellationToken ct = default)
   {
      ct.ThrowIfCancellationRequested();

      IReadOnlyList<string> ids = _scripts.Keys
          .OrderBy(x => x, StringComparer.OrdinalIgnoreCase)
          .ToList();

      return Task.FromResult(ids);
   }

   public Task<bool> DeleteAsync(
       string scriptId,
       CancellationToken ct = default)
   {
      if (string.IsNullOrWhiteSpace(scriptId))
         throw new ArgumentException("scriptId must be provided.", nameof(scriptId));
      ct.ThrowIfCancellationRequested();

      var removed = _scripts.TryRemove(scriptId, out _);
      return Task.FromResult(removed);
   }

   public Task<bool> ExistsAsync(
       string scriptId,
       CancellationToken ct = default)
   {
      if (string.IsNullOrWhiteSpace(scriptId))
         throw new ArgumentException("scriptId must be provided.", nameof(scriptId));
      ct.ThrowIfCancellationRequested();

      return Task.FromResult(_scripts.ContainsKey(scriptId));
   }

   // --- Optional deep clone helpers (enable if you want copy-on-write/read semantics) ---

   private static T? DeepClone<T>(T value)
   {
      if (value is null) return default;
      var json = JsonSerializer.Serialize(value);
      return JsonSerializer.Deserialize<T>(json);
   }
}