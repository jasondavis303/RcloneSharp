using System.Text.Json.Serialization;

namespace RcloneSharp.Requests;

public class HashSumRequest : SingleFSRequest
{
    /// <summary>
    /// Type of hash to be used
    /// </summary>
    public required string HashType { get; set; }

    /// <summary>
    /// Check by downloading rather than with hash (boolean)
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool Download { get; set; }

    /// <summary>
    /// Output the hashes in base64 rather than hex (boolean)
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool Base64 { get; set; }
}
