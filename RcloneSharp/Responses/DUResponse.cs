using System.Text.Json.Serialization;

namespace RcloneSharp.Responses;

public class DUResponse
{
    public class DUInfo
    {
        public long Available { get; set; }

        public long Free { get; set; }

        public long Total { get; set; }
    }

    [JsonPropertyName("dir")]
    public required string Directory { get; set; }

    public required DUInfo Info { get; set; }
}
