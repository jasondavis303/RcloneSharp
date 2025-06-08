namespace RcloneSharp.Requests;

public class FSAndRemoteRequest : SingleFSRequest
{
    /// <summary>
    /// A path within that remote e.g. "dir"
    /// </summary>
    public string? Remote { get; set; }
}
