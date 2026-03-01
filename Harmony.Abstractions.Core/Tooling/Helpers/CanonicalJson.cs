
// /Harmony.Abstractions/Harmony.Tooling/Helpers/CanonicalJson.cs
using System.Text;
using System.Text.Json;

// -------------------------------------------------------------------------------------------------
namespace Harmony.Tooling.Helpers;

/// <summary>
/// Canonical JSON serializer for consistent hashing and comparison of JSON structures. It ensures
/// that JSON objects are serialized with their properties in a consistent order (lexicographically)
/// and that arrays and primitive values are serialized in a standard way. This is useful for 
/// scenarios like hashing JSON content, comparing JSON structures for equality, or generating 
/// consistent signatures for JSON data. 
/// </summary>
internal static class CanonicalJson
{
   // Minimal canonicalizer: orders object properties lexicographically.
   public static string Serialize(JsonElement element)
   {
      var sb = new StringBuilder();
      WriteCanonical(element, sb);
      return sb.ToString();
   }

   /// <summary>
   /// WriteCanonical recursively writes the JSON element to the StringBuilder in a canonical form. 
   /// For objects, it orders the properties by name. For arrays, it writes the elements in order. 
   /// For primitive values, it writes them in a standard way. This ensures that the same JSON 
   /// structure will always produce the same string representation, regardless of the original 
   /// formatting or property order. 
   /// </summary>
   /// <param name="el"></param>
   /// <param name="sb"></param>
   private static void WriteCanonical(JsonElement el, StringBuilder sb)
   {
      switch (el.ValueKind)
      {
         case JsonValueKind.Object:
            sb.Append('{');
            var props = el.EnumerateObject().OrderBy(p => p.Name, StringComparer.Ordinal);
            bool first = true;
            foreach (var p in props)
            {
               if (!first) sb.Append(',');
               first = false;
               sb.Append('"').Append(p.Name).Append('"').Append(':');
               WriteCanonical(p.Value, sb);
            }
            sb.Append('}');
            break;
         case JsonValueKind.Array:
            sb.Append('[');
            bool afirst = true;
            foreach (var v in el.EnumerateArray())
            {
               if (!afirst) sb.Append(',');
               afirst = false;
               WriteCanonical(v, sb);
            }
            sb.Append(']');
            break;
         case JsonValueKind.String:
            sb.Append('"').Append(el.GetString()).Append('"');
            break;
         case JsonValueKind.Number:
         case JsonValueKind.True:
         case JsonValueKind.False:
         case JsonValueKind.Null:
            sb.Append(el.ToString());
            break;
         default:
            sb.Append("null"); break;
      }
   }
}
