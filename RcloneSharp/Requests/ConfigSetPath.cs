namespace RcloneSharp.Requests;

public class ConfigSetPath : Base
{
    /// <summary>
    /// path to the config file to use
    /// </summary>
    public required string Path { get; set; }
}
