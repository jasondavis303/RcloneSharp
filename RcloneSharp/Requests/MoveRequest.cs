namespace RcloneSharp.Requests;

public class MoveRequest : SyncRequest
{
    /// <summary>
    /// delete empty src directories if set
    /// </summary>
    public bool DeleteEmptySrcDirs { get; set; }
}
