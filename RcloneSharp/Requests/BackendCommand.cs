using System.Text.Json.Serialization;

namespace RcloneSharp.Requests;

public class BackendCommand : SingleFS
{
    /// <summary>
    /// a string with the command name
    /// </summary>
    public required string Command { get; set; }

    /// <summary>
    /// a list of arguments for the backend command
    /// </summary>
    [JsonPropertyName("arg")]
    public List<string> Arguments { get; set; } = [];

    /// <summary>
    /// a map of string to string of options
    /// </summary>
    [JsonPropertyName("opt")]
    public Dictionary<string, string?> Options { get; set; } = [];
}
