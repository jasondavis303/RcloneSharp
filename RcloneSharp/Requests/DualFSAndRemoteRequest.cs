using System.Text.Json.Serialization;

namespace RcloneSharp.Requests;

public class DualFSAndRemoteRequest : DualFSRequest
{
    /// <summary>
    /// A path within that remote e.g. "file.txt" for the source
    /// </summary>
    [JsonPropertyName("srcRemote")]
    public string? SourceRemote { get; set; }

    /// <summary>
    /// A path within that remote e.g. "file2.txt" for the destination
    /// </summary>
    [JsonPropertyName("dstRemote")]
    public string? DestinationRemote { get; set; }
}
