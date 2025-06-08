using System.Text.Json.Serialization;

namespace RcloneSharp.Requests;

public class RemoveDirectoriesRequest : FSAndRemoteRequest
{
    /// <summary>
    /// Set to true not to delete the root
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool LeaveRoot { get; set; }
}
