using System.Text.Json.Serialization;

namespace RcloneSharp.Requests;

public class Base
{
    [JsonPropertyName("_async")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool Async { get; set; }

    [JsonPropertyName("_config")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dictionary<string, object>? Config { get; set; }

    [JsonPropertyName("_filter")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dictionary<string, object>? Filter { get; set; }

    [JsonPropertyName("_group")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Group { get; set; }
}
