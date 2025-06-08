using System.Text.Json.Serialization;

namespace RcloneSharp.Responses;

public class CheckResponse
{
    public bool Success { get; set; }

    /// <summary>
    /// Textual summary of check, OK or text string
    /// </summary>
    public required string Status { get; set; }

    /// <summary>
    /// Hash used in check, may be missing
    /// </summary>
    public string? HashType { get; set; }

    /// <summary>
    /// Combined report of changes
    /// </summary>
    public List<string> Combined { get; set; } = [];

    /// <summary>
    /// All files missing from the source
    /// </summary>
    [JsonPropertyName("missingOnSrc")]
    public List<string> MissingOnSource { get; set; } = [];

    /// <summary>
    /// All files missing from the destination
    /// </summary>
    [JsonPropertyName("missingOnDst")]
    public List<string> MissingOnDestination { get; set; } = [];

    /// <summary>
    /// All matching files
    /// </summary>
    [JsonPropertyName("match")]
    public List<string> Matches { get; set; } = [];

    /// <summary>
    /// All non-matching files
    /// </summary>
    [JsonPropertyName("differ")]
    public List<string> Differences { get; set; } = [];

    /// <summary>
    /// All files with errors (hashing or reading)
    /// </summary>
    [JsonPropertyName("error")]
    public List<string> Errors { get; set; } = [];
}
