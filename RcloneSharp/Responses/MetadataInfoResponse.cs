namespace RcloneSharp.Responses;

public class MetadataInfoResponse
{
    public SystemResponse? System { get; set; }

    public required string Help { get; set; }
}
