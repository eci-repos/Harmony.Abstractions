
// /Harmony.Abstractions/Harmony.Tooling/Helpers/InputHash.cs
using System.Text;
using System.Text.Json;
using System.Security.Cryptography;

// -------------------------------------------------------------------------------------------------
namespace Harmony.Tooling.Helpers;

/// <summary>
/// InputHash computes a consistent hash for a given JSON element. It first serializes the JSON
/// element into a canonical form using the CanonicalJson helper, which ensures that the same JSON
/// structure will always produce the same string representation regardless of formatting or
/// property order. Then, it computes a SHA-256 hash of the canonical string and returns it as a
/// hexadecimal string. This is useful for scenarios where you want to generate a unique
/// identifier for a JSON structure, compare JSON content, or detect changes in JSON data. 
/// </summary>
public static class InputHash
{
   /// <summary>
   /// Compute a consistent hash for a given JSON element by first serializing it into a canonical
   /// form and then hashing the resulting string using SHA-256. The output is a hexadecimal 
   /// string representation of the hash. 
   /// </summary>
   /// <param name="element"></param>
   /// <returns></returns>
   public static string Compute(JsonElement element)
   {
      var canonical = CanonicalJson.Serialize(element);
      var hash = SHA256.HashData(Encoding.UTF8.GetBytes(canonical));
      return Convert.ToHexString(hash);
   }
}
