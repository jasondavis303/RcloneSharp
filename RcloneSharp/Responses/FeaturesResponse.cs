namespace RcloneSharp.Responses;

public class FeaturesResponse
{
    public bool About { get; set; }

    public bool BucketBased { get; set; }

    public bool BucketBasedRootOK { get; set; }

    public bool CanHaveEmptyDirectories { get; set; }

    public bool CaseInsensitive { get; set; }

    public bool ChangeNotify { get; set; }

    public bool CleanUp { get; set; }

    public bool Command { get; set; }

    public bool Copy { get; set; }

    public bool DirCacheFlush { get; set; }

    public bool DirMove { get; set; }

    public bool Disconnect { get; set; }

    public bool DuplicateFiles { get; set; }

    public bool GetTier { get; set; }

    public bool IsLocal { get; set; }

    public bool ListR { get; set; }

    public bool MergeDirs { get; set; }

    public bool MetadataInfo { get; set; }

    public bool Move { get; set; }

    public bool OpenWriterAt { get; set; }

    public bool PublicLink { get; set; }

    public bool Purge { get; set; }

    public bool PutStream { get; set; }

    public bool PutUnchecked { get; set; }

    public bool ReadMetadata { get; set; }

    public bool ReadMimeType { get; set; }

    public bool ServerSideAcrossConfigs { get; set; }

    public bool SetTier { get; set; }

    public bool SetWrapper { get; set; }

    public bool Shutdown { get; set; }

    public bool SlowHash { get; set; }

    public bool SlowModTime { get; set; }

    public bool UnWrap { get; set; }

    public bool UserInfo { get; set; }

    public bool UserMetadata { get; set; }

    public bool WrapFs { get; set; }

    public bool WriteMetadata { get; set; }

    public bool WriteMimeType { get; set; }
}
