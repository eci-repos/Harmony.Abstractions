
// /Harmony.Abstractions/Models/KnownErrorCodes.cs

// -------------------------------------------------------------------------------------------------
namespace Harmony.Abstractions.Models;

public static class KnownErrorCodes
{
   public const string ValidationError = "ValidationError";
   public const string DependencyMissing = "DependencyMissing";
   public const string Timeout = "Timeout";
   public const string Unauthorized = "Unauthorized";
   public const string Forbidden = "Forbidden";
   public const string NotFound = "NotFound";
   public const string DomainNotAllowed = "DomainNotAllowed";
   public const string RateLimited = "RateLimited";
   public const string BackendError = "BackendError";
}
