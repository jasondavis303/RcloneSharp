using System.Text.Json.Serialization;

namespace RcloneSharp.Requests;

public class DualFSAndRemote : DualFS
{
    [JsonPropertyName("srcRemote")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? SourceRemote { get; set; }

    [JsonPropertyName("dstRemote")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? DestinationRemote { get; set; }
}
