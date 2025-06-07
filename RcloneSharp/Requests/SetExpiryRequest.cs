using System.Text.Json.Serialization;

namespace RcloneSharp.Requests;

public class SetExpiryRequest
{
    /// <summary>
    /// If this parameter is not supplied and if there is only one VFS in use then that VFS will be used. If there is more than one VFS in use then the "fs" parameter must be supplied.
    /// </summary>
    public string? FS { get; set; }

    /// <summary>
    /// a numeric ID as returned from vfs/queue
    /// </summary>
    public int ID { get; set; }

    /// <summary>
    /// a new expiry time as floating point seconds
    /// </summary>
    public float Expiry { get; set; }

    /// <summary>
    /// if set, expiry is to be treated as relative to the current expiry
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool Relative { get; set; }
}
