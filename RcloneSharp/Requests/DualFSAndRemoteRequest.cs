using System.Text.Json.Serialization;

namespace RcloneSharp.Requests;

public class DualFSAndRemoteRequest : DualFSRequest
{
    /// <summary>
    /// a path within that remote e.g. "file.txt" for the source
    /// </summary>
    [JsonPropertyName("srcRemote")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? SourceRemote { get; set; }

    /// <summary>
    /// a path within that remote e.g. "file2.txt" for the destination
    /// </summary>
    [JsonPropertyName("dstRemote")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? DestinationRemote { get; set; }
}
