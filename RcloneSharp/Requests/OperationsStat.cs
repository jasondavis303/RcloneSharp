using System.Text.Json.Serialization;

namespace RcloneSharp.Requests;

public class OperationsStat : FSAndRemote
{
    /// <summary>
    /// options to control the listing (optional)
    /// see operations/list for the options
    /// </summary>
    [JsonPropertyName("opt")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dictionary<string, object>? Options { get; set; }
}
