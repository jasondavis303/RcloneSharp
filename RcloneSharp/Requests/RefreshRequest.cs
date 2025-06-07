using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace RcloneSharp.Requests;

public class RefreshRequest : BaseRequest, ICustomRequestSerialization
{
    [JsonPropertyName("fs")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? FS { get; set; }

    [JsonPropertyName("dirs")]
    public List<string> Directories { get; set; } = [];

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool Recursive { get; set; }

    public JsonObject GetJsonObject()
    {
        JsonObject? ret = new()
        {
            { "recursive", Recursive }
        };

        if (!string.IsNullOrWhiteSpace(FS))
            ret.Add("fs", FS);

        for(int i = 0; i < Directories.Count; i++)
            ret.Add($"dir{i}", Directories[i]);

        AddBaseRequestData(ret);

        return ret;
    }
}
