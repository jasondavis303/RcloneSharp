using System.Text.Json.Serialization;

namespace RcloneSharp.Responses;

public class CheckResponse
{
    public bool Success { get; set; }

    /// <summary>
    /// textual summary of check, OK or text string
    /// </summary>
    public required string Status { get; set; }

    /// <summary>
    /// hash used in check, may be missing
    /// </summary>
    public string? HashType { get; set; }

    /// <summary>
    /// combined report of changes
    /// </summary>
    public List<string> Combined { get; set; } = [];

    /// <summary>
    /// all files missing from the source
    /// </summary>
    [JsonPropertyName("missingOnSrc")]
    public List<string> MissingOnSource { get; set; } = [];

    /// <summary>
    /// all files missing from the destination
    /// </summary>
    [JsonPropertyName("missingOnDst")]
    public List<string> MissingOnDestination { get; set; } = [];

    /// <summary>
    /// all matching files
    /// </summary>
    [JsonPropertyName("match")]
    public List<string> Matches { get; set; } = [];

    /// <summary>
    /// all non-matching files
    /// </summary>
    [JsonPropertyName("differ")]
    public List<string> Differences { get; set; } = [];

    /// <summary>
    /// all files with errors (hashing or reading)
    /// </summary>
    [JsonPropertyName("error")]
    public List<string> Errors { get; set; } = [];
}
