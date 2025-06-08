namespace RcloneSharp.Requests;

public class MoveRequest : SyncRequest
{
    /// <summary>
    /// Delete empty src directories if set
    /// </summary>
    public bool DeleteEmptySrcDirs { get; set; }
}
