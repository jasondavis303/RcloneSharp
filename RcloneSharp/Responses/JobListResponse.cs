namespace RcloneSharp.Responses;

public class JobListResponse
{
    /// <summary>
    /// id of rclone executing (change after restart)
    /// </summary>
    public required string ExecuteId { get; set; }

    /// <summary>
    /// integer job ids (starting at 1 on each restart)
    /// </summary>
    public List<int> JobIds { get; set; } = [];
}
