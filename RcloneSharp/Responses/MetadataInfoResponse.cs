namespace RcloneSharp.Responses;

public class MetadataInfoResponse
{
    public required SystemResponse System { get; set; }

    public required string Help { get; set; }
}
