namespace RcloneSharp.Responses;

public class FSInfoResponse
{
    public required FeaturesResponse Features { get; set; }

    public List<string> Hashes { get; set; } = [];

    public int Precision { get; set; }

    public required string Root { get; set; }

    public required string String { get; set; }

    public required MetadataInfoResponse MetadataInfo { get; set; }
}
