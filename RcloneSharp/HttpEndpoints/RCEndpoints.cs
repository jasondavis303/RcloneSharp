using RcloneSharp.Responses;
using System.Text.Json.Nodes;

namespace RcloneSharp.HttpEndpoints;

public class RCEndpoints
{
    readonly HttpRC _rc;

    internal RCEndpoints(HttpRC rc) => _rc = rc;

    /// <summary>
    /// This returns an error with the input as part of its error string. Useful for testing error handling.
    /// </summary>
    public Task<Response> Error(JsonObject? request = null, CancellationToken cancellationToken = default) =>
        _rc.Post("rc/error", request, cancellationToken);

    /// <summary>
    /// This returns an error with the input as part of its error string. Useful for testing error handling.
    /// </summary>
    public Task<Response> NoOp(JsonObject? request = null, CancellationToken cancellationToken = default) =>
        _rc.Post("rc/noop", request, cancellationToken);


    /// <summary>
    /// This lists all the registered remote control commands as a JSON map in the commands response.
    /// </summary>
    public Task<Response<JsonObject>> List(CancellationToken cancellationToken = default) =>
        _rc.PostAndReturnData<JsonObject>("rc/list", null, cancellationToken);


    /// <summary>
    /// This returns an error with the input as part of its error string. Useful for testing error handling.
    /// </summary>
    public Task<Response> NoOpAuth(JsonObject? request = null, CancellationToken cancellationToken = default) =>
        _rc.Post("rc/noopauth", request, cancellationToken);

}
