namespace RcloneSharp.Responses;

public class AboutResponse
{
    public long? Total { get; set; }

    public long? Used { get; set; }

    public long? Free { get; set; }

    public long? Trashed { get; set; }

    public long? Other { get; set; }

    public long? Objects { get; set; }
}
