namespace RcloneSharp.Requests;

public class FSAndRemote : SingleFS
{
    /// <summary>
    /// a path within that remote e.g. "dir"
    /// </summary>
    public string? Remote { get; set; }
}
