using System.Text.Json.Serialization;

namespace RcloneSharp.Requests;

public class BisyncRequest : BaseRequest
{
    /// <summary>
    /// A remote directory string e.g. drive:path1
    /// </summary>
    public required string Path1 { get; set; }

    /// <summary>
    /// A remote directory string e.g. drive:path2
    /// </summary>
    public required string Path2 { get; set; }

    /// <summary>
    /// dry-run mode
    /// </summary>
    public bool DryRun { get; set; }

    /// <summary>
    /// Performs the resync run
    /// </summary>
    public bool Resync { get; set; }

    /// <summary>
    /// Abort if RCLONE_TEST files are not found on both filesystems
    /// </summary>
    public bool CheckAccess { get; set; }

    /// <summary>
    /// File name for checkAccess (default: RCLONE_TEST)
    /// </summary>
    public required string CheckFilename { get; set; } = "RCLONE_TEST";

    /// <summary>
    /// Abort sync if percentage of deleted files is above this threshold (default: 50)
    /// </summary>
    public int MaxDelete { get; set; } = 50;

    /// <summary>
    /// Bypass <see cref="MaxDelete"/>> safety check and run the sync
    /// </summary>
    public bool Force { get; set; }

    /// <summary>
    /// True by default, false disables comparison of final listings, only will skip sync, only compare listings from the last run
    /// </summary>
    public bool CheckSync { get; set; } = true;

    /// <summary>
    /// Sync creation and deletion of empty directories. (Not compatible with --remove-empty-dirs)
    /// </summary>
    [JsonPropertyName("createEmptySrcDirs")]
    public bool CreateEmptySourceDirectories { get; set; }

    /// <summary>
    /// Remove empty directories at the final cleanup step
    /// </summary>
    [JsonPropertyName("removeEmptyDirs")]
    public bool RemoveEmptyDirectories { get; set; }

    /// <summary>
    /// Read filtering patterns from a file
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? FiltersFile { get; set; }

    /// <summary>
    /// Do not use checksums for listings
    /// </summary>
    public bool IgnoreListingChecksum { get; set; }

    /// <summary>
    /// Allow future runs to retry after certain less-serious errors, instead of requiring resync. Use at your own risk!
    /// </summary>
    public bool Resilient { get; set; }

    /// <summary>
    /// Server directory for history files (default: ~/.cache/rclone/bisync)
    /// </summary>
    [JsonPropertyName("workdir")]
    public string? WorkDirectory { get; set; }

    /// <summary>
    /// Backup-dir for Path1. Must be a non-overlapping path on the same remote.
    /// </summary>
    [JsonPropertyName("backupdir1")]
    public string? BackupDirectory1 { get; set; }

    /// <summary>
    /// Backup-dir for Path2. Must be a non-overlapping path on the same remote.
    /// </summary>
    [JsonPropertyName("backupdir2")]
    public string? BackupDirectory2 { get; set; }

    /// <summary>
    /// Retain working files
    /// </summary>
    public bool NoCleanup { get; set; }
}
