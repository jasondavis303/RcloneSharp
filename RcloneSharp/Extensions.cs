using System.Text.Json.Nodes;

namespace RcloneSharp;

internal static class Extensions
{
    public static JsonObject? AsJsonObject(this string? value, string name)
    {
        if (string.IsNullOrWhiteSpace(value))
            return null;

        return new()
        {
            { name, value }
        };
    }

    public static JsonObject? AsJsonObject(this int? value, string name)
    {
        if (value is null)
            return null;

        return new()
        {
            { name, value }
        };
    }


    public static JsonObject? AsJsonObject(this int value, string name) =>
        new()
        {
            { name, value }
        };

    public static JsonObject? AsJsonObject(this bool value, string name) =>
        new()
        {
            { name, value }
        };
}
