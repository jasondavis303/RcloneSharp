namespace RcloneSharp.Requests;

public class SetTierFileRequest : SetTierRequest
{
    /// <summary>
    /// a path within that remote e.g. "dir"
    /// </summary>
    public required string Remote { get; set; }
}
