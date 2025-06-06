namespace RcloneSharp.Requests;

public class OptionsInfo : Base
{
    /// <summary>
    /// optional string of comma separated blocks to include.
    /// all are included if this is missing or ""
    /// </summary>
    public string? Blocks { get; set; }
}
