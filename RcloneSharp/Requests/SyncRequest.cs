namespace RcloneSharp.Requests;

public class SyncRequest : DualFSRequest
{
    public bool CreateEmptySrcDirs { get; set; }
}
