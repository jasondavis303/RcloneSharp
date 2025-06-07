using System.Text.Json.Nodes;

namespace RcloneSharp.Requests;

public class ForgetRequest : BaseRequest, ICustomRequestSerialization
{
    /// <summary>
    /// If this parameter is not supplied and if there is only one VFS in use then that VFS will be used. 
    /// If there is more than one VFS in use then the "fs" parameter must be supplied.
    /// </summary>
    public string? FS { get; set; }

    /// <summary>
    /// Optional directories to forget. If no directories or files are passed in then it will forget all the paths in the directory cache.
    /// </summary>
    public List<string> Directories { get; set; } = [];

    /// <summary>
    /// Optional files to forget. If no directories or files are passed in then it will forget all the paths in the directory cache.
    /// </summary>
    public List<string> Files { get; set; } = [];

    public JsonObject GetJsonObject()
    {
        JsonObject ret = [];

        if (!string.IsNullOrWhiteSpace(FS))
            ret.Add("fs", FS);

        for (int i = 0; i < Directories.Count; i++)
            ret.Add($"dir{i}", Directories[i]);

        for (int i = 0; i < Files.Count; i++)
            ret.Add($"file{i}", Files[i]);

        AddBaseRequestData(ret);

        return ret;
    }
}
