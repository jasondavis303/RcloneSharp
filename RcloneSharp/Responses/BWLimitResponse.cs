namespace RcloneSharp.Responses;

public class BWLimitResponse
{
    public long BytesPerSecond { get; set; }

    public long BytesPerSecondTx { get; set; }

    public long BytesPerSecondRx { get; set; }

    public required string Rate { get; set; }
}
