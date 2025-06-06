namespace RcloneSharp.Requests;

public class CacheExpire : Base
{
    /// <summary>
    /// path to remote (required)
    /// </summary>
    public required string Remote { get; set; }

    /// <summary>
    /// true/false to delete cached data (chunks) as well (optional)
    /// </summary>
    public bool WithData { get; set; }
}
