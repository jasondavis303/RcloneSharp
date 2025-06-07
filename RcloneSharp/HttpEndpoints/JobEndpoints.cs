using RcloneSharp.Responses;

namespace RcloneSharp.HttpEndpoints;

public class JobEndpoints
{
    readonly HttpRC _rc;

    internal JobEndpoints(HttpRC rc) => _rc = rc;


    /// <summary>
    /// Lists the IDs of the running jobs
    /// </summary>
    public Task<Response<JobListResponse>> JobList(CancellationToken cancellationToken = default) =>
        _rc.PostAndReturnData<JobListResponse>("job/joblist", null, cancellationToken);


    /// <summary>
    /// Reads the status of the job
    /// </summary>
    public Task<Response<JobStatusResponse>> Status(int jobId, CancellationToken cancellationToken = default) =>
        _rc.PostAndReturnData<JobStatusResponse>("job/status", jobId.AsJsonObject("jobid"), cancellationToken);


    /// <summary>
    /// Stops the running job
    /// </summary>
    public Task<Response> Stop(int jobId, CancellationToken cancellationToken = default) =>
        _rc.Post("job/stop", jobId.AsJsonObject("jobid"), cancellationToken);


    /// <summary>
    /// Stop all running jobs in a group
    /// </summary>
    public Task<Response> StopGroup(string group, CancellationToken cancellationToken = default) =>
        _rc.Post("job/stopgroup", group.AsJsonObject("group"), cancellationToken);
}
