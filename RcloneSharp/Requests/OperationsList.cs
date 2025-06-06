using System.Text.Json.Serialization;

namespace RcloneSharp.Requests;

public class OperationsList : FSAndRemote
{
    /// <summary>
    /// a dictionary of options to control the listing (optional)
    /// </summary>
    public Dictionary<string, object>? Options { get; set; }

    /// <summary>
    /// If set recurse directories
    /// </summary>
    public bool Recurse { get; set; }

    /// <summary>
    /// If set don't return modification time
    /// </summary>
    public bool NoModTime { get; set; }

    /// <summary>
    /// If set show decrypted names
    /// </summary>
    public bool ShowEncrypted { get; set; }

    /// <summary>
    /// If set show the IDs for each item if known
    /// </summary>
    [JsonPropertyName("showOrigIDs")]
    public bool ShowOrigIds { get; set; }

    /// <summary>
    /// If set return a dictionary of hashes
    /// </summary>
    public bool ShowHash { get; set; }

    /// <summary>
    /// If set don't show mime types
    /// </summary>
    public bool NoMimeType { get; set; }

    /// <summary>
    /// If set only show directories
    /// </summary>
    [JsonPropertyName("dirsOnly")]
    public bool DirectoriesOnly { get; set; }

    /// <summary>
    /// If set only show files
    /// </summary>
    public bool FilesOnly { get; set; }

    /// <summary>
    /// If set return metadata of objects also
    /// </summary>
    public bool Metadata { get; set; }

    /// <summary>
    /// array of strings of hash types to show if showHash set
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter<HashTypes>))]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<HashTypes>? HashTypes { get; set; }
}