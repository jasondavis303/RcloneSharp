namespace RcloneSharp.Requests;

public class SetTierRequest : SingleFSRequest
{
    public required string Tier { get; set; }
}
