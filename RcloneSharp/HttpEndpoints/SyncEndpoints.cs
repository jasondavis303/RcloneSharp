using RcloneSharp.Requests;
using RcloneSharp.Responses;

namespace RcloneSharp.HttpEndpoints;

public class SyncEndpoints
{
    readonly HttpRC _rc;

    internal SyncEndpoints(HttpRC rc) => _rc = rc;

    /// <summary>
    /// Perform bidirectional synchronization between two paths.
    public Task<Response> BiSync(BisyncRequest request, CancellationToken cancellationToken = default) =>
        _rc.Post("sync/bisync", request, cancellationToken);

    /// <summary>
    /// copy a directory from source remote to destination remote
    /// </summary>
    public Task<Response> Copy(SyncRequest request, CancellationToken cancellationToken = default) =>
        _rc.Post("sync/copy", request, cancellationToken);

    /// <summary>
    /// move a directory from source remote to destination remote
    /// </summary>
    public Task<Response> Move(MoveRequest request, CancellationToken cancellationToken = default) =>
        _rc.Post("sync/move", request, cancellationToken);


    /// <summary>
    /// sync a directory from source remote to destination remote
    /// </summary>
    public Task<Response> Sync(SyncRequest request, CancellationToken cancellationToken = default) =>
        _rc.Post("sync/sync", request, cancellationToken);
}
