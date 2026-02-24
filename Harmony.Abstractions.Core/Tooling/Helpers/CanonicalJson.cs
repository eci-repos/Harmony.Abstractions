
// /Harmony.Abstractions/Harmony.Tooling/Helpers/CanonicalJson.cs
using System.Text;
using System.Text.Json;

// -------------------------------------------------------------------------------------------------
namespace Harmony.Tooling.Helpers;

internal static class CanonicalJson
{
   // Minimal canonicalizer: orders object properties lexicographically.
   public static string Serialize(JsonElement element)
   {
      var sb = new StringBuilder();
      WriteCanonical(element, sb);
      return sb.ToString();
   }

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
