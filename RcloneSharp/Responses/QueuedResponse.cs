namespace RcloneSharp.Responses;

public class QueuedResponse
{
    /// <summary>
    /// name (full path) of the file
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// id of this item in the queue
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// size of the file in bytes
    /// </summary>
    public long Size { get; set; }

    /// <summary>
    /// time until file is eligible for transfer, lowest goes first
    /// </summary>
    public float Expiry { get; set; }

    /// <summary>
    /// number of times we have tried to upload
    /// </summary>
    public int Tries { get; set; }

    /// <summary>
    /// seconds between upload attempts
    /// </summary>
    public float Delay { get; set; }

    /// <summary>
    /// true if item is being uploaded
    /// </summary>
    public bool Uploading { get; set; }
}
