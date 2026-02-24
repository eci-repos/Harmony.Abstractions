
// Permissive: never blocks (good for local dev)
// -------------------------------------------------------------------------------------------------
// This file defines several implementations of IToolAvailability, which is an interface that
// determines whether a given tool is available for use. The implementations include:
using Harmony.Tooling.Discovery;
using Harmony.Tooling.Models;
using Harmony.Tooling.Contracts;

using System.Diagnostics.Contracts;
using System.Reflection;

namespace Harmony.Tooling.Discovery;

public sealed class AllowAllToolAvailability : IToolAvailability
{
   public Task<bool> IsAvailableAsync(string recipient, CancellationToken ct = default)
       => Task.FromResult(true);

   public Task<IReadOnlyCollection<string>> ListAvailableAsync(CancellationToken ct = default)
       => Task.FromResult((IReadOnlyCollection<string>)Array.Empty<string>());

   public Task<ToolDescriptor?> DescribeAsync(string recipient, CancellationToken ct = default)
       => Task.FromResult<ToolDescriptor?>(null);
}

// Restrictive: blocks all (safe default in production until configured)
public sealed class DenyAllToolAvailability : IToolAvailability
{
   public static readonly DenyAllToolAvailability Instance = new();

   public Task<bool> IsAvailableAsync(string recipient, CancellationToken ct = default)
       => Task.FromResult(false);

   public Task<IReadOnlyCollection<string>> ListAvailableAsync(CancellationToken ct = default)
       => Task.FromResult((IReadOnlyCollection<string>)Array.Empty<string>());

   public Task<ToolDescriptor?> DescribeAsync(string recipient, CancellationToken ct = default)
       => Task.FromResult<ToolDescriptor?>(null);
}
