using System.Text.Json.Serialization;

namespace RcloneSharp.Requests;

public class MountMount : SingleFS
{
    public enum MountTypes
    {
        Mount,
        CMount,
        Mount2
    }

    /// <summary>
    /// valid path on the local machine (required)
    /// </summary>
    public required string MountPoint { get; set; }

    /// <summary>
    /// one of <see cref="MountTypes"/> that specifies the mount implementation to use
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter<MountTypes>))]
    public MountTypes MountType { get; set; }


    [JsonPropertyName("mountOpt")]
    public Dictionary<string, object> MountOptions { get; set; } = [];

    [JsonPropertyName("vfsOpt")]
    public Dictionary<string, object> VFSOptions { get; set; } = [];
}
