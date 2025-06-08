namespace RcloneSharp.Responses;

public class FSInfoResponse
{
    public required string Name { get; set; }

    public required FeaturesResponse Features { get; set; }

    public List<string> Hashes { get; set; } = [];

    public int Precision { get; set; }

    public required string Root { get; set; }

    public required string String { get; set; }

    public MetadataInfoResponse? MetadataInfo { get; set; }
}
