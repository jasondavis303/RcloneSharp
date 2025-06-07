namespace RcloneSharp.Responses;

public class DiskCacheResponse
{
    public long BytesUsed { get; set; }

    public int ErrorFiles { get; set; }

    public int Files { get; set; }

    public int HashType { get; set; }

    public bool OutOfSpace { get; set; }

    public required string Path { get; set; }

    public required string PathMeta { get; set; }

    public int UploadsInProgress { get; set; }

    public int UploadsQueued { get; set; }
}