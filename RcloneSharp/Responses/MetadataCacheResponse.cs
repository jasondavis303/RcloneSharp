using System.Text.Json.Serialization;

namespace RcloneSharp.Responses;

public class MetadataCacheResponse
{
    [JsonPropertyName("dirs")]
    public int Directories { get; set; }

    public int Files { get; set; }
}
