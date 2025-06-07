using RcloneSharp.Requests;
using RcloneSharp.Responses;

namespace RcloneSharp.HttpEndpoints;

public class MountEndpoints
{
    readonly HttpRC _rc;

    internal MountEndpoints(HttpRC rc) => _rc = rc;

    /// <summary>
    /// This shows currently mounted points, which can be used for performing an unmount.
    /// </summary>
    public Task<Response<List<string>>> ListMounts(CancellationToken cancellationToken = default) =>
        _rc.PostAndReturnDataFlattened<List<string>>("mount/listmounts", null, "mountPoints", cancellationToken);


    /// <summary>
    /// Create a new mount point
    /// </summary>
    public Task<Response> Mount(MountRequest request, CancellationToken cancellationToken = default) =>
        _rc.Post("mount/mount", request, cancellationToken);


    /// <summary>
    /// This shows all possible mount types
    /// </summary>
    public Task<Response<List<string>>> Types(CancellationToken cancellationToken = default) =>
        _rc.PostAndReturnDataFlattened<List<string>>("mount/types", null, "mountTypes", cancellationToken);


    /// <summary>
    /// Unmount selected active mount
    /// </summary>
    public Task<Response> Unmount(string mountPoint, CancellationToken cancellationToken = default) =>
        _rc.Post("mount/unmount", mountPoint.AsJsonObject("mountPoint"), cancellationToken);

    /// <summary>
    /// Unmount all active mounts
    /// </summary>
    public Task<Response> UnmountAll(CancellationToken cancellationToken = default) =>
        _rc.Post("mount/unmountall", null, cancellationToken);
}
