using System.Text.Json.Serialization;

namespace RcloneSharp.Requests;

public class DualFSRequest : BaseRequest
{
    /// <summary>
    /// a remote name string e.g. "drive:" for the source, "/" for local filesystem
    /// </summary>
    [JsonPropertyName("srcFs")]
    public required string SourceFS { get; set; }

    /// <summary>
    /// a remote name string e.g. "drive:" for the destination, "/" for local filesystem
    /// </summary>
    [JsonPropertyName("dstFs")]
    public required string DestinationFS { get; set; }
}
