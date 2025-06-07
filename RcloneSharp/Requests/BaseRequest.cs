using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace RcloneSharp.Requests;

public class BaseRequest
{
    [JsonPropertyName("_async")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool Async { get; set; }

    [JsonPropertyName("_config")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public JsonObject? Config { get; set; }

    [JsonPropertyName("_filter")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public JsonObject? Filter { get; set; }

    [JsonPropertyName("_group")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Group { get; set; }

    internal void AddBaseRequestData(JsonObject jsonObject)
    {
        if (Async)
            jsonObject.Add("_async", true);

        if (Config != null)
            jsonObject.Add("_config", Config);

        if (Filter != null)
            jsonObject.Add("_filter", Filter);

        if (!string.IsNullOrWhiteSpace(Group))
            jsonObject.Add("_group", Group);
    }
}
