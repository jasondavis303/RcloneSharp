namespace RcloneSharp.Requests;

public  class SyncMove : SyncSync
{
    /// <summary>
    /// delete empty src directories if set
    /// </summary>
    public bool DeleteEmptySrcDirs { get; set; }
}
