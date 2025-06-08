namespace RcloneSharp.Responses;

public class StatsResponse
{
    public class TransferInfo
    {
        /// <summary>
        /// total transferred bytes for this file,
        /// </summary>
        public long Bytes { get; set; }

        /// <summary>
        /// estimated time in seconds until file transfer completion
        /// </summary>
        public long? Eta { get; set; }

        /// <summary>
        /// name of the file
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// progress of the file transfer in percent
        /// </summary>
        public int Percentage { get; set; }

        /// <summary>
        /// average speed over the whole transfer in bytes per second
        /// </summary>
        public double Speed { get; set; }

        /// <summary>
        /// current speed in bytes per second as an exponentially weighted moving average
        /// </summary>
        public double SpeedAvg { get; set; }

        /// <summary>
        /// size of the file in bytes
        /// </summary>
        public long Size { get; set; }
    }

    /// <summary>
    /// Total transferred bytes since the start of the group
    /// </summary>
    public long Bytes { get; set; }

    /// <summary>
    /// Number of files checked
    /// </summary>
    public int Checks { get; set; }

    /// <summary>
    /// Number of files deleted
    /// </summary>
    public int Deletes { get; set; }

    /// <summary>
    /// Time in floating point seconds since rclone was started
    /// </summary>
    public float ElapsedTime { get; set; }

    /// <summary>
    /// Number of errors
    /// </summary>
    public int Errors { get; set; }

    /// <summary>
    /// Estimated time in seconds until the group completes
    /// </summary>
    public long? Eta { get; set; }

    /// <summary>
    /// Whether there has been at least one fatal error
    /// </summary>
    public bool FatalError { get; set; }

    /// <summary>
    /// Last error string
    /// </summary>
    public string? LastError { get; set; }

    /// <summary>
    /// Number of files renamed
    /// </summary>
    public int Renames { get; set; }

    /// <summary>
    /// Whether there has been at least one non-NoRetryError
    /// </summary>
    public bool RetryError { get; set; }

    /// <summary>
    /// Number of server side copies done
    /// </summary>
    public int ServerSideCopies { get; set; }

    /// <summary>
    /// Number bytes server side copied
    /// </summary>
    public long ServerSideCopyBytes { get; set; }

    /// <summary>
    /// Number of server side moves done
    /// </summary>
    public int ServerSideMoves { get; set; }

    /// <summary>
    /// Number bytes server side moved
    /// </summary>
    public long ServerSideMoveBytes { get; set; }

    /// <summary>
    /// Average speed in bytes per second since start of the group
    /// </summary>
    public double Speed { get; set; }

    /// <summary>
    /// Total number of bytes in the group
    /// </summary>
    public long TotalBytes { get; set; }

    /// <summary>
    /// Total number of checks in the group
    /// </summary>
    public int TotalChecks { get; set; }

    /// <summary>
    /// Total number of transfers in the group
    /// </summary>
    public int TotalTransfers { get; set; }

    /// <summary>
    /// Total time spent on running jobs
    /// </summary>
    public float TransferTime { get; set; }

    /// <summary>
    /// Number of transferred files
    /// </summary>
    public int Transfers { get; set; }

    /// <summary>
    /// Currently active file transfers
    /// </summary>
    public List<TransferInfo> Transferring { get; set; } = [];

    /// <summary>
    /// Names of currently active file checks
    /// </summary>
    public List<string> Checking { get; set; } = [];
}
