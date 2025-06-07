using RcloneSharp.Responses;

namespace RcloneSharp.HttpEndpoints;

public class FsCacheEndpoints
{
    readonly HttpRC _rc;

    internal FsCacheEndpoints(HttpRC rc) => _rc = rc;

    /// <summary>
    /// This clears the fs cache. This is where remotes created from backends are cached for a short while to make repeated rc calls more efficient.
    /// </summary>
    public Task<Response> Clear(CancellationToken cancellationToken = default) =>
        _rc.Post("fscache/clear", null, cancellationToken);


    /// <summary>
    /// This returns the number of entries in the fs cache.
    /// </summary>
    public Task<Response<int>> Entries(CancellationToken cancellationToken = default) =>
        _rc.PostAndReturnDataFlattened<int>("fscache/entries", null, "entries", cancellationToken);
}
