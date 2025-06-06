using System.Text.Json.Serialization;

namespace RcloneSharp.Requests;

public class CoreDiskUsage : Base
{
    /// <summary>
    /// If the directory is not passed in, it defaults to the directory pointed to by --cache-dir.
    /// </summary>
    [JsonPropertyName("dir")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Directory { get; set; }
}
