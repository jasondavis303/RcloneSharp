namespace RcloneSharp.Requests;

public class OperationsCopyUrl : FSAndRemote
{
    /// <summary>
    /// string, URL to read from
    /// </summary>
    public required string Url { get; set; }

    /// <summary>
    /// boolean, set to true to retrieve destination file name from url
    /// </summary>
    public bool AutoFilename { get; set; }
}
