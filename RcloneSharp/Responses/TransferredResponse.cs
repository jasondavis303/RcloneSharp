namespace RcloneSharp.Responses;

public class TransferredResponse
{
    /// <summary>
    /// name of the file
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// size of the file in bytes
    /// </summary>
    public long Size { get; set; }

    /// <summary>
    /// total transferred bytes for this file
    /// </summary>
    public long Bytes { get; set; }

    /// <summary>
    /// if the transfer is only checked (skipped, deleted)
    /// </summary>
	public bool Checked { get; set; }

    /// <summary>
    /// integer representing millisecond unix epoch
    /// </summary>
	public long Timestamp { get; set; }

    /// <summary>
    /// string description of the error (empty if successful)
    /// </summary>
	public string? Error { get; set; }

    /// <summary>
    /// id of the job that this transfer belongs to
    /// </summary>
	public int JobId { get; set; }
}
