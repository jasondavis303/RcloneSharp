using System.Text.Json.Serialization;

namespace RcloneSharp.Requests;

public class DualFS : Base
{
    [JsonPropertyName("srcFs")]
    public required string SourceFS { get; set; }

    [JsonPropertyName("dstFs")]
    public required string DestinationFS { get; set; }
}
