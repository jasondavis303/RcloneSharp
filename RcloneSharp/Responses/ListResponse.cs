using System.Text.Json.Nodes;

namespace RcloneSharp.Responses;

public class ListResponse
{
    public HashesResponse? Hashes { get; set; }

    public string? ID { get; set; }

    public string? OrigID { get; set; }

    public bool IsBucket { get; set; }

    public bool IsDir { get; set; }

    public required string MimeType { get; set; }

    public DateTimeOffset ModTime { get; set; }

    public required string Name { get; set; }

    public string? Encrypted { get; set; }

    public string? EncryptedPath { get; set; }

    public required string Path { get; set; }

    public long Size { get; set; }

    public string? Tier { get; set; }

    public JsonObject? Metadata { get; set; }
}
