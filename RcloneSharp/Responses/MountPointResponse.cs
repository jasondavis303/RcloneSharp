namespace RcloneSharp.Responses;

public class MountPointResponse
{
    public required string Fs { get; set; }

    public required string MountPoint { get; set; }

    public DateTime MountedOn { get; set; }
}
