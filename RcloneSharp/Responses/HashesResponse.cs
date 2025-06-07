using System.Text.Json.Serialization;

namespace RcloneSharp.Responses;

public class HashesResponse
{
    [JsonPropertyName("SHA-1")]
    public string? SHA1 { get; set; }

    public string? MD5 { get; set; }

    public string? DropboxHash { get; set; }

}
