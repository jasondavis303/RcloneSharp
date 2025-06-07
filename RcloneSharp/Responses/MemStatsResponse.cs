namespace RcloneSharp.Responses;

public class MemStatsResponse
{
    public long Alloc { get; set; }

    public long BuckHashSys { get; set; }

    public long Frees { get; set; }

    public long GCSys { get; set; }

    public long HeapAlloc { get; set; }

    public long HeapIdle { get; set; }

    public long HeapInuse { get; set; }

    public long HeapObjects { get; set; }

    public long HeapReleased { get; set; }

    public long HeapSys { get; set; }

    public long MCacheInuse { get; set; }

    public long MCacheSys { get; set; }

    public long Mallocs { get; set; }

    public long OtherSys { get; set; }

    public long StackInuse { get; set; }

    public long StackSys { get; set; }

    public long Sys { get; set; }

    public long TotalAlloc { get; set; }
}
