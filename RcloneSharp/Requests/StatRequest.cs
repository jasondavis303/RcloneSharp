using System.Text.Json.Serialization;

namespace RcloneSharp.Requests;

public class StatRequest : FSAndRemoteRequest
{
    /// <summary>
    /// Options to control the listing (optional).
    /// See operations/list for the options
    /// </summary>
    [JsonPropertyName("opt")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dictionary<string, object>? Options { get; set; }
}
