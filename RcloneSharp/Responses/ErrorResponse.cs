using System.Net;
using System.Text.Json.Nodes;

namespace RcloneSharp.Responses;

public class ErrorResponse
{
    public ErrorResponse() { }

    public required string Error { get; set; }

    public required string Path { get; set; }

    public HttpStatusCode? Status { get; set; }

    public JsonObject? Input { get; set; }
}
