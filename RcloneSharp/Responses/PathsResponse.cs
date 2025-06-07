namespace RcloneSharp.Responses;

public class PathsResponse
{
    public required string Cache { get; set; }

    public required string Config { get; set; }

    public required string Temp { get; set; }
}
