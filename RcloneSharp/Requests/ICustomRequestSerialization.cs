using System.Text.Json.Nodes;

namespace RcloneSharp.Requests;

internal interface ICustomRequestSerialization
{
    JsonObject GetJsonObject();
}
