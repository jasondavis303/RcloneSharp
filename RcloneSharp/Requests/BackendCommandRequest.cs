using System.Text.Json.Serialization;

namespace RcloneSharp.Requests;

public class BackendCommandRequest : SingleFSRequest
{
    /// <summary>
    /// A string with the command name
    /// </summary>
    public required string Command { get; set; }

    /// <summary>
    /// A list of arguments for the backend command
    /// </summary>
    [JsonPropertyName("arg")]
    public List<string>? Arguments { get; set; }

    /// <summary>
    /// A map of string to string of options
    /// </summary>
    [JsonPropertyName("opt")]
    public Dictionary<string, string?>? Options { get; set; }
}
