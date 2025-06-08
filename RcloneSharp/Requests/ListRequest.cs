using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace RcloneSharp.Requests;

public class ListRequest : FSAndRemoteRequest
{
    /// <summary>
    /// A dictionary of options to control the listing (optional)
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Dictionary<string, JsonObject>? Options { get; set; }

    /// <summary>
    /// If set recurse directories
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool Recurse { get; set; }

    /// <summary>
    /// If set don't return modification time
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool NoModTime { get; set; }

    /// <summary>
    /// If set show decrypted names
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool ShowEncrypted { get; set; }

    /// <summary>
    /// If set show the IDs for each item if known
    /// </summary>
    [JsonPropertyName("showOrigIDs")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool ShowOrigIds { get; set; }

    /// <summary>
    /// If set return a dictionary of hashes
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool ShowHash { get; set; }

    /// <summary>
    /// If set don't show mime types
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool NoMimeType { get; set; }

    /// <summary>
    /// If set only show directories
    /// </summary>
    [JsonPropertyName("dirsOnly")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool DirectoriesOnly { get; set; }

    /// <summary>
    /// If set only show files
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool FilesOnly { get; set; }

    /// <summary>
    /// If set return metadata of objects also
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool Metadata { get; set; }

    /// <summary>
    /// Hash types to show if showHash set
    /// </summary>
    public List<string>? HashTypes { get; set; }
}