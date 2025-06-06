namespace RcloneSharp.Requests;

public class OperationsRemoveDirectories : FSAndRemote
{
    /// <summary>
    /// set to true not to delete the root
    /// </summary>
    public bool LeaveRoot { get; set; }
}
