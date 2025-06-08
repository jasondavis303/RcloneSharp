namespace RcloneSharp.Requests;

public class RemoveDirectoriesRequest : FSAndRemoteRequest
{
    /// <summary>
    /// Set to true not to delete the root
    /// </summary>
    public bool LeaveRoot { get; set; }
}
