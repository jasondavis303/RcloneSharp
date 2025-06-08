namespace RcloneSharp.Requests;

public class CopyUrlRequest : FSAndRemoteRequest
{
    /// <summary>
    /// String, URL to read from
    /// </summary>
    public required string Url { get; set; }

    /// <summary>
    /// Boolean, set to true to retrieve destination file name from url
    /// </summary>
    public bool AutoFilename { get; set; }
}
