using System.Text.Json.Serialization;

namespace RcloneSharp.Requests;

public class PublicLinkRequest : FSAndRemoteRequest
{
    /// <summary>
    /// If set removes the link rather than adding it (optional)
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Unlink { get; set; }

    /// <summary>
    /// The expiry time of the link e.g. "1d" (optional)
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Expire { get; set; }
}
