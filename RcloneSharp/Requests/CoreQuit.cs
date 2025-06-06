using System.Text.Json.Serialization;

namespace RcloneSharp.Requests;

public class CoreQuit : Base
{
    /// <summary>
    /// (Optional) Pass an exit code to be used for terminating the app:
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? ExitCode { get; set; }
}
