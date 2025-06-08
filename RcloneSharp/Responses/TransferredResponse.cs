namespace RcloneSharp.Responses;

public class TransferredResponse
{
    /// <summary>
    /// Name of the file
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Size of the file in bytes
    /// </summary>
    public long Size { get; set; }

    /// <summary>
    /// Total transferred bytes for this file
    /// </summary>
    public long Bytes { get; set; }

    /// <summary>
    /// If the transfer is only checked (skipped, deleted)
    /// </summary>
	public bool Checked { get; set; }

    /// <summary>
    /// Integer representing millisecond unix epoch
    /// </summary>
	public long Timestamp { get; set; }

    /// <summary>
    /// String description of the error (empty if successful)
    /// </summary>
	public string? Error { get; set; }

    /// <summary>
    /// Id of the job that this transfer belongs to
    /// </summary>
	public int JobId { get; set; }
}
