using RcloneSharp.Requests;
using RcloneSharp.Responses;

namespace RcloneSharp.HttpEndpoints;

public class BackendEndpoints
{
    readonly HttpRC _rc;

    internal BackendEndpoints(HttpRC rc) => _rc = rc;

    /// <summary>
    /// Runs a backend command.
    /// </summary>
    public Task<Response<T>> Command<T>(BackendCommandRequest request, CancellationToken cancellationToken = default) =>
        _rc.PostAndReturnData<T>("backend/command", request, cancellationToken);
}
