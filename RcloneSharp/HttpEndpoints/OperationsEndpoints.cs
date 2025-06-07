using RcloneSharp.Requests;
using RcloneSharp.Responses;

namespace RcloneSharp.HttpEndpoints;

/*
    operations/uploadfile
    --------------------------
    this is for multiform data. 
    However, since the help page is 404,
    and this doesn't really fit into the scheme of the api,
    I'm excluding it.
*/

public class OperationsEndpoints
{
    readonly HttpRC _rc;

    internal OperationsEndpoints(HttpRC rc) => _rc = rc;

    /// <summary>
    /// Return the space used on the remote
    /// </summary>
    /// <param name="fs">a remote name string e.g. "drive:"</param>
    public Task<Response<AboutResponse>> About(SingleFSRequest request, CancellationToken cancellationToken = default) =>
        _rc.PostAndReturnData<AboutResponse>("operations/about", request, cancellationToken);


    /// <summary>
    /// Checks the files in the source and destination match. It compares sizes and hashes and logs a report of files that don't match. It doesn't alter the source or destination.
    /// </summary>
    public Task<Response<CheckResponse>> Check(CheckRequest request, CancellationToken cancellationToken = default) =>
        _rc.PostAndReturnData<CheckResponse>("operations/check", request, cancellationToken);


    /// <summary>
    /// Remove trashed files in the remote or path
    /// </summary>
    public Task<Response> Cleanup(SingleFSRequest request, CancellationToken cancellationToken = default) =>
        _rc.Post("operations/cleanup", request, cancellationToken);


    /// <summary>
    /// Copy a file from source remote to destination remote
    /// </summary>
    public Task<Response> CopyFile(DualFSAndRemoteRequest request, CancellationToken cancellationToken = default) =>
        _rc.Post("operations/copyfile", request, cancellationToken);


    /// <summary>
    /// Copy the URL to the object
    /// </summary>
    public Task<Response> CopyUrl(CopyUrlRequest request, CancellationToken cancellationToken = default) =>
        _rc.Post("operations/copyurl", request, cancellationToken);


    /// <summary>
    /// Remove files in the path
    /// </summary>
    public Task<Response> Delete(SingleFSRequest request, CancellationToken cancellationToken = default) =>
        _rc.Post("operations/delete", request, cancellationToken);


    /// <summary>
    /// Remove the single file pointed to
    /// </summary>
    public Task<Response> DeleteFile(FSAndRemoteRequest request, CancellationToken cancellationToken = default) =>
        _rc.Post("operations/deletefile", request, cancellationToken);


    /// <summary>
    /// Return information about the remote
    /// </summary>
    /// <param name="fs">a remote name string e.g. "drive:"</param>
    public Task<Response<FSInfoResponse>> FsInfo(string fs, CancellationToken cancellationToken = default) =>
        _rc.PostAndReturnData<FSInfoResponse>("operations/fsinfo", fs.AsJsonObject("fs"), cancellationToken);


    /// <summary>
    /// Produces a hashsum file for all the objects in the path.
    /// </summary>
    public Task<Response<HashSumResponse>> HashSum(HashSumRequest request, CancellationToken cancellationToken = default) =>
        _rc.PostAndReturnData<HashSumResponse>("operations/hashsum", request, cancellationToken);


    /// <summary>
    /// List directories and objects in the path. 
    /// 
    /// Do NOT incude stat in the requestion options, or the response will fail to deserialize. Instead, call <see cref="Stat"/>
    /// </summary>
    public Task<Response<List<ListResponse>>> List(ListRequest request, CancellationToken cancellationToken = default) =>
        _rc.PostAndReturnDataFlattened<List<ListResponse>>("operations/list", request, "list", cancellationToken);


    /// <summary>
    /// ake a destination directory or container
    /// </summary>
    public Task<Response> MakeDirectory(FSAndRemoteRequest request, CancellationToken cancellationToken = default) =>
        _rc.Post("operations/mkdir", request, cancellationToken);


    /// <summary>
    /// Move a file from source remote to destination remote
    /// </summary>
    public Task<Response> MoveFile(DualFSAndRemoteRequest request, CancellationToken cancellationToken = default) =>
        _rc.Post("operations/movefile", request, cancellationToken);


    /// <summary>
    /// Create or retrieve a public link to the given file or folder.
    /// </summary>
    public Task<Response<string>> PublicLink(PublicLinkRequest request, CancellationToken cancellationToken = default) =>
        _rc.PostAndReturnDataFlattened<string>("operations/publiclink", request, "url", cancellationToken);


    /// <summary>
    /// Remove a directory or container and all of its contents
    /// </summary>
    public Task<Response> Purge(FSAndRemoteRequest request, CancellationToken cancellationToken = default) =>
        _rc.Post("operations/purge", request, cancellationToken);

    /// <summary>
    /// Remove an empty directory or container
    /// </summary>
    public Task<Response> RemoveDirectory(FSAndRemoteRequest request, CancellationToken cancellationToken = default) =>
        _rc.Post("operations/rmdir", request, cancellationToken);

    /// <summary>
    /// Remove all the empty directories in the path
    /// </summary>
    public Task<Response> RemoveDirectories(RemoveDirectoriesRequest request, CancellationToken cancellationToken = default) =>
        _rc.Post("operations/rmdirs", request, cancellationToken);


    //TODO: settier and settierfile - how do you pass in the tier?

    /// <summary>
    /// Count the number of bytes and files in remote
    /// </summary>
    public Task<Response<SizeResponse>> Size(SingleFSRequest request, CancellationToken cancellationToken = default) =>
        _rc.PostAndReturnData<SizeResponse>("operations/size", request, cancellationToken);


    /// <summary>
    /// Give information about the supplied file or directory
    /// </summary>
    public Task<Response<ListResponse>> Stat(StatRequest request, CancellationToken cancellationToken = default) =>
        _rc.PostAndReturnData<ListResponse>("operations/stat", request, cancellationToken);
}
