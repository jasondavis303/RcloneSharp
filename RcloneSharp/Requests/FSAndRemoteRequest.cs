namespace RcloneSharp.Requests;

public class FSAndRemoteRequest : SingleFSRequest
{
    /// <summary>
    /// a path within that remote e.g. "dir"
    /// </summary>
    public string? Remote { get; set; }
}
