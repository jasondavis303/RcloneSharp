namespace RcloneSharp.Requests;

public class PublicLinkRequest : FSAndRemoteRequest
{
    /// <summary>
    /// If set removes the link rather than adding it (optional)
    /// </summary>
    public bool? Unlink { get; set; }

    /// <summary>
    /// The expiry time of the link e.g. "1d" (optional)
    /// </summary>
    public string? Expire { get; set; }
}
