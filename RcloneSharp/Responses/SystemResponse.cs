namespace RcloneSharp.Responses;

public class SystemResponse
{
    public required SystemTypeResponse ATime { get; set; }

    public required SystemTypeResponse BTime { get; set; }

    public required SystemTypeResponse GID { get; set; }

    public required SystemTypeResponse Mode { get; set; }

    public required SystemTypeResponse MTime { get; set; }

    public required SystemTypeResponse RDev { get; set; }

    public required SystemTypeResponse UID { get; set; }
}
