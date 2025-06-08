using System.Text.Json.Serialization;

namespace RcloneSharp.Requests;

public class MountRequest : SingleFSRequest
{
    /// <summary>
    /// Valid path on the local machine (required)
    /// </summary>
    public required string MountPoint { get; set; }

    /// <summary>
    /// One of [mount, cmount, mount2] that specifies the mount implementation to use.
    /// 
    /// If no mountType is provided, the priority is given as follows: 1. mount 2. cmount 3. mount2
    /// </summary>
    public string? MountType { get; set; }

    [JsonPropertyName("mountOpt")]
    public Dictionary<string, object> MountOptions { get; set; } = [];

    [JsonPropertyName("vfsOpt")]
    public Dictionary<string, object> VFSOptions { get; set; } = [];
}
