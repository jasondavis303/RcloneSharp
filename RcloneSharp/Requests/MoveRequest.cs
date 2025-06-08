using System.Text.Json.Serialization;

namespace RcloneSharp.Requests;

public class MoveRequest : SyncRequest
{
    /// <summary>
    /// Delete empty src directories if set
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool DeleteEmptySrcDirs { get; set; }
}
