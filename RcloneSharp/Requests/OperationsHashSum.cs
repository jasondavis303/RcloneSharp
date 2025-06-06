using System.Text.Json.Serialization;

namespace RcloneSharp.Requests;

public class OperationsHashSum : SingleFS
{
    /// <summary>
    /// type of hash to be used
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter<HashTypes>))]
    public HashTypes HashType { get; set; }

    /// <summary>
    /// check by downloading rather than with hash (boolean)
    /// </summary>
    public bool Download { get; set; }

    /// <summary>
    /// output the hashes in base64 rather than hex (boolean)
    /// </summary>
    public bool Base64 { get; set; }
}
