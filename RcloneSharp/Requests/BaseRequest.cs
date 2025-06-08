using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace RcloneSharp.Requests;

public class BaseRequest
{
    [JsonPropertyName("_async")]
    public bool Async { get; set; }

    [JsonPropertyName("_config")]
    public JsonObject? Config { get; set; }

    [JsonPropertyName("_filter")]
    public JsonObject? Filter { get; set; }

    [JsonPropertyName("_group")]
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
