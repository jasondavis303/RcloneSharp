namespace RcloneSharp.Responses;

public class PollIntervalResponse
{
    public class IntervalResponse
    {
        public long Raw { get; set; }

        public int Seconds { get; set; }

        public required string String { get; set; }
    }

    public bool Enabled { get; set; }

    public IntervalResponse? Interval { get; set; }

    public bool Supported { get; set; }
}