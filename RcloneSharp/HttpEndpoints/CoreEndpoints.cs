using RcloneSharp.Responses;

namespace RcloneSharp.HttpEndpoints;

/*
    Excluded:
        core/command    - because isn't the point to use the api?
        core/gc         - the Go runtime should correctly handle it
        core/obscure    - used for config file changes, which are not handled in RcloneSharp
        
*/

public class CoreEndpoints
{
    readonly HttpRC _rc;

    internal CoreEndpoints(HttpRC rc) => _rc = rc;

    /// <summary>
    /// Set the bandwidth limit.
    /// </summary>
    /// <param name="rate">This should be a single bandwidth limit entry or a pair of upload:download bandwidth.</param>
    public Task<Response<BWLimitResponse>> BWLimit(string rate = "off", CancellationToken cancellationToken = default) =>
        _rc.PostAndReturnData<BWLimitResponse>("core/bwlimit", rate.AsJsonObject("rate"), cancellationToken);


    /// <summary>
    /// This returns the disk usage for the local directory passed in as dir.
    /// 
    /// If the directory is not passed in, it defaults to the directory pointed to by --cache-dir.
    /// </summary>
    public Task<Response<DUResponse>> DU(string? dir = null, CancellationToken cancellationToken = default) =>
        _rc.PostAndReturnData<DUResponse>("core/du", dir.AsJsonObject("dir"), cancellationToken);


    /// <summary>
    /// This returns list of stats groups currently in memory.
    /// </summary>
    public Task<Response<List<string>>> GroupList(CancellationToken cancellationToken = default) =>
        _rc.PostAndReturnDataFlattened<List<string>>("core/group-list", null, "groups", cancellationToken);


    /// <summary>
    /// This returns the memory statistics of the running program. What the values mean are explained in the go docs: https://golang.org/pkg/runtime/#MemStats
    /// </summary>
    public Task<Response<MemStatsResponse>> MemStats(CancellationToken cancellationToken = default) =>
        _rc.PostAndReturnData<MemStatsResponse>("core/memstats", null, cancellationToken);


    /// <summary>
    /// This returns PID of current process. Useful for stopping rclone process.
    /// </summary>
    public Task<Response<int>> PID(CancellationToken cancellationToken = default) =>
        _rc.PostAndReturnDataFlattened<int>("core/pid", null, "pid", cancellationToken);

    /// <summary>
    /// Terminates the app.
    /// </summary>
    /// <param name="exitCode">(Optional) Pass an exit code to be used for terminating the app</param>
    public Task<Response> Exit(int? exitCode = null, CancellationToken cancellationToken = default) =>
        _rc.Post("core/quit", exitCode.AsJsonObject("exitCode"), cancellationToken);


    /// <summary>
    /// Returns stats about current transfers.
    /// </summary>
    /// <param name="group">If group is not provided then summed up stats for all groups will be returned</param>
    public Task<Response<StatsResponse>> Stats(string? group = null, CancellationToken cancellationToken = default) =>
        _rc.PostAndReturnData<StatsResponse>("core/stats", group.AsJsonObject("group"), cancellationToken);


    /// <summary>
    /// Delete stats group.
    /// </summary>
    public Task<Response> StatsDelete(string group, CancellationToken cancellationToken = default) =>
        _rc.Post("core/stats-delete", group.AsJsonObject("group"), cancellationToken);


    /// <summary>
    /// This clears counters, errors and finished transfers for all stats or specific stats group if group is provided.
    /// </summary>
    public Task<Response> StatsReset(string? group = null, CancellationToken cancellationToken = default) =>
        _rc.Post("core/stats-reset", group.AsJsonObject("group"), cancellationToken);

    /// <summary>
    /// Returns stats about completed transfers.
    /// Note only the last 100 completed transfers are returned.
    /// </summary>
    /// <param name="group">If group is not provided then completed transfers for all groups will be returned.</param>
    public Task<Response<List<TransferredResponse>>> Transferred(string? group = null, CancellationToken cancellationToken = default) =>
        _rc.PostAndReturnDataFlattened<List<TransferredResponse>>("core/transferred", group.AsJsonObject("group"), "transferred", cancellationToken);


    /// <summary>
    /// Shows the current version of rclone and the go runtime.
    /// </summary>
    public Task<Response<VersionResponse>> Version(CancellationToken cancellationToken = default) =>
        _rc.PostAndReturnData<VersionResponse>("core/version", null, cancellationToken);

}
