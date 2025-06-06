namespace RcloneSharp.Requests;

public class CoreBWLimit : Base
{
    /// <summary>
    /// This should be a single bandwidth limit entry or a pair of upload:download bandwidth.
    /// </summary>
    public required string Rate { get; set; }
}
