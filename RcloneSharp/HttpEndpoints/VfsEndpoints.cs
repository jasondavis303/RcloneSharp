using RcloneSharp.Requests;
using RcloneSharp.Responses;
using System.Text.Json.Nodes;

namespace RcloneSharp.HttpEndpoints;

public class VfsEndpoints
{
    readonly HttpRC _rc;

    internal VfsEndpoints(HttpRC rc) => _rc = rc;

    /// <summary>
    /// This forgets the paths in the directory cache causing them to be re-read from the remote when needed.
    /// </summary>
    public Task<Response> Forget(ForgetRequest request, CancellationToken cancellationToken = default) =>
        _rc.Post("vfs/forget", request, cancellationToken);


    /// <summary>
    /// This lists the active VFSes.
    /// </summary>
    public Task<Response<List<string>>> List(CancellationToken cancellationToken = default) =>
        _rc.PostAndReturnDataFlattened<List<string>>("vfs/list", null, "vfses", cancellationToken);


    /// <summary>
    /// Get the status or update the value of the poll-interval option.
    /// </summary>
    /// <param name="newInterval">New interval as a string. E.g. "1m". When set, the poll-interval value is updated and the polling function is notified. Setting interval=0 disables poll-interval.</param>
    public Task<Response<PollIntervalResponse>> GetPollInterval(string? newInterval = null, CancellationToken cancellationToken = default) =>
        _rc.PostAndReturnData<PollIntervalResponse>("vfs/poll-interval", newInterval.AsJsonObject("interval"), cancellationToken);

    /// <summary>
    /// Get the status or update the value of the poll-interval option.
    /// </summary>
    /// <param name="newInterval">New interval in seconds. When set, the poll-interval value is updated and the polling function is notified. Setting interval=0 disables poll-interval.</param>
    public Task<Response<PollIntervalResponse>> GetPollInterval(int? newInterval = null, CancellationToken cancellationToken = default) =>
        _rc.PostAndReturnData<PollIntervalResponse>("vfs/poll-interval", newInterval.AsJsonObject("interval"), cancellationToken);


    /// <summary>
    /// This returns info about the upload queue for the selected VFS.
    /// </summary>
    /// <param name="fs">If this parameter is not supplied and if there is only one VFS in use then that VFS will be used. If there is more than one VFS in use then the "fs" parameter must be supplied.</param>
    public Task<Response<List<QueuedResponse>>> Queued(string? fs = null, CancellationToken cancellationToken = default) =>
        _rc.PostAndReturnDataFlattened<List<QueuedResponse>>("vfs/queued", fs.AsJsonObject("fs"), "queued", cancellationToken);


    /// <summary>
    /// Set the expiry time for an item queued for upload.
    /// </summary>
    public Task<Response> SetExpiry(SetExpiryRequest request, CancellationToken cancellationToken = default) =>
        _rc.Post("vfs/queue-set-expiry", request, cancellationToken);


    /// <summary>
    /// This reads the directories for the specified paths and freshens the directory cache.
    /// If no paths are passed in then it will refresh the root directory.
    /// </summary>
    public Task<Response> Refresh(RefreshRequest request, CancellationToken cancellationToken = default) =>
        _rc.Post("vfs/refresh", request, cancellationToken);
}
