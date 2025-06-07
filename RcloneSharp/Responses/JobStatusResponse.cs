using System.Text.Json.Nodes;

namespace RcloneSharp.Responses;

public class JobStatusResponse
{
    /// <summary>
    ///  whether the job has finished or not
    /// </summary>
    public bool Finished { get; set; }

    /// <summary>
    /// time in seconds that the job ran for
    /// </summary>
    public int Duration { get; set; }

    /// <summary>
    /// time the job finished
    /// </summary>
    public DateTimeOffset? EndTime { get; set; }

    /// <summary>
    /// error from the job or empty string for no error
    /// </summary>
    public string? Error { get; set; }

    /// <summary>
    /// as passed in above
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// time the job started
    /// </summary>
    public DateTimeOffset StartTime { get; set; }

    public bool Success { get; set; }

    /// <summary>
    /// output of the job as would have been returned if called synchronously
    /// </summary>
    public JsonObject? Output { get; set; }


    //TODO!!!

    /// <summary>
    /// output of the progress related to the underlying job
    /// </summary>
    public JsonObject? Progress { get; set; }
}
