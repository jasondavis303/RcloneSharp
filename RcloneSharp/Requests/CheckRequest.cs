using System.Text.Json.Serialization;

namespace RcloneSharp.Requests;

/// <summary>
/// Checks the files in the source and destination match. It compares sizes and hashes and logs a report of files that don't match. It doesn't alter the source or destination.
/// 
/// If you supply the download flag, it will download the data from both remotes and check them against each other on the fly. This can be useful for remotes that don't support hashes or if you really want to check all the data.
/// 
/// If you supply the size-only global flag, it will only compare the sizes not the hashes as well. Use this for a quick check.
/// 
/// If you supply the CheckFileHash option with a valid hash name, the checkFileFs:checkFileRemote must point to a text file in the SUM format. This treats the checksum file as the source and dstFs as the destination. Note that srcFs is not used and should not be supplied in this case.
/// </summary>
public class CheckRequest : BaseRequest
{
    /// <summary>
    /// A remote name string e.g. "drive:" for the source, "/" for local filesystem
    /// </summary>
    [JsonPropertyName("srcFs")]
    public required string SourceFS { get; set; }

    /// <summary>
    /// A remote name string e.g. "drive2:" for the destination, "/" for local filesystem
    /// </summary>
    [JsonPropertyName("dstFs")]
    public required string DestinationFS { get; set; }

    /// <summary>
    /// Check by downloading rather than with hash
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool Download { get; set; }

    /// <summary>
    /// Treat checkFileFs:checkFileRemote as a SUM file with hashes of given type
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool CheckFileHash { get; set; }

    /// <summary>
    /// Treat checkFileFs:checkFileRemote as a SUM file with hashes of given type
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool CheckFileFS { get; set; }

    /// <summary>
    /// Treat checkFileFs:checkFileRemote as a SUM file with hashes of given type
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool CheckFileRemote { get; set; }

    /// <summary>
    /// Check one way only, source files must exist on remote
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool OneWay { get; set; }

    /// <summary>
    /// Make a combined report of changes (default false)
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool Combined { get; set; }

    /// <summary>
    /// Report all files missing from the source (default true)
    /// </summary>
    [JsonPropertyName("missingOnSrc")]
    public bool MissingOnSource { get; set; } = true;

    /// <summary>
    /// Report all files missing from the destination (default true)
    /// </summary>
    [JsonPropertyName("missingOnDst")]
    public bool MissingOnDestination { get; set; } = true;

    /// <summary>
    /// Report all matching files (default false)
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool ReportAllMatchingFiles { get; set; }

    /// <summary>
    /// Report all non-matching files (default true)
    /// </summary>
    public bool Differ { get; set; } = true;

    /// <summary>
    /// Report all files with errors (hashing or reading) (default true)
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool Error { get; set; } = true;
}
