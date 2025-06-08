namespace RcloneSharp.Responses;

public class SystemResponse
{
    public SystemTypeResponse? ATime { get; set; }

    public SystemTypeResponse? BTime { get; set; }

    public SystemTypeResponse? GID { get; set; }

    public SystemTypeResponse? Mode { get; set; }

    public SystemTypeResponse? MTime { get; set; }

    public SystemTypeResponse? RDev { get; set; }

    public SystemTypeResponse? UID { get; set; }
}
