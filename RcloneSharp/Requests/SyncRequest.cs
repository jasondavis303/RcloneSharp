using System.Text.Json.Serialization;

namespace RcloneSharp.Requests;

public class SyncRequest : DualFSRequest
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool CreateEmptySrcDirs { get; set; }
}
