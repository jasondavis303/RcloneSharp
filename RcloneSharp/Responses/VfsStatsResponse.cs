using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace RcloneSharp.Responses;

public class VfsStatsResponse
{
    public DiskCacheResponse? DiskCache { get; set; }

    public required string FS { get; set; }

    public int InUse { get; set; }

    public required MetadataCacheResponse MetadatCache { get; set; }

    [JsonPropertyName("opt")]
    public JsonObject Options { get; set; } = [];
}
