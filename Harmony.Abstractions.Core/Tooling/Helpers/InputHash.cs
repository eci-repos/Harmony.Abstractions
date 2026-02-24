
// /Harmony.Abstractions/Harmony.Tooling/Helpers/InputHash.cs
using System.Text;
using System.Text.Json;
using System.Security.Cryptography;

// -------------------------------------------------------------------------------------------------
namespace Harmony.Tooling.Helpers;

public static class InputHash
{
   public static string Compute(JsonElement element)
   {
      var canonical = CanonicalJson.Serialize(element);
      var hash = SHA256.HashData(Encoding.UTF8.GetBytes(canonical));
      return Convert.ToHexString(hash);
   }
}
