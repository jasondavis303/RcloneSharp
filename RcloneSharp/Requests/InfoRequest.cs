namespace RcloneSharp.Requests;

public class InfoRequest : BaseRequest
{
    /// <summary>
    /// Optional string of comma separated blocks to include.
    /// All are included if this is missing or ""
    /// </summary>
    public string? Blocks { get; set; }
}
