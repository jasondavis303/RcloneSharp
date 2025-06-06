using System.Text.Json.Serialization;

namespace RcloneSharp.Requests;

public class SingleFS : Base
{
    /// <summary>
    /// a remote name string e.g. "drive:", "/" for local filesystem
    /// </summary>
    [JsonPropertyName("fs")]
    public required string FS { get; set; }
}
