namespace RcloneSharp.Responses;

public class HashSumResponse
{
    public required string HashType { get; set; }

    public List<string> HashSum { get; set; } = [];
}
