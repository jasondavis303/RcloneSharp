using System.Text.Json.Serialization;

namespace RcloneSharp.Responses;

public class VersionResponse
{
    [JsonPropertyName("arch")]
    public required string Architecture { get; set; }

    [JsonPropertyName("decomposed")]
    public required List<int> VersionDecomposed { get; set; }

    public required string GoTags { get; set; }

    public required string GoVersion { get; set; }

    public bool IsBeta { get; set; }

    public bool IsGet { get; set; }

    public required string Linking { get; set; }

    public required string OS { get; set; }

    public required string Version { get; set; }
}
