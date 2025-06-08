using RcloneSharp.Responses;
using System.Text.Json.Nodes;

namespace RcloneSharp.HttpEndpoints;

/*
    No endpoints that change the config file are included 
*/

public class ConfigEndpoints
{
    readonly HttpRC _rc;

    internal ConfigEndpoints(HttpRC rc) => _rc = rc;

    /// <summary>
    /// Dumps the config file.
    /// </summary>
    public Task<Response<JsonObject>> Dump(CancellationToken cancellationToken = default) =>
        _rc.PostAndReturnData<JsonObject>("config/dump", null, cancellationToken);

    /// <summary>
    /// Get a remote in the config file.
    /// </summary>
    public Task<Response<JsonObject>> Get(string name, CancellationToken cancellationToken = default) =>
        _rc.PostAndReturnData<JsonObject>("config/get", name.AsJsonObject("name"), cancellationToken);


    /// <summary>
    ///  Lists the remotes in the config file and defined in environment variables.
    /// </summary>
    public Task<Response<List<string>>> ListRemotes(CancellationToken cancellationToken = default) =>
        _rc.PostAndReturnDataFlattened<List<string>>("config/listremotes", null, "remotes", cancellationToken);


    /// <summary>
    /// Reads the config file path and other important paths.
    /// </summary>
    public Task<Response<PathsResponse>> Paths(CancellationToken cancellationToken = default) =>
        _rc.PostAndReturnData<PathsResponse>("config/paths", null, cancellationToken);


    /// <summary>
    /// Shows how providers are configured in the config file.
    /// </summary>
    public Task<Response<JsonObject>> Providers(CancellationToken cancellationToken = default) =>
        _rc.PostAndReturnData<JsonObject>("config/providers", null, cancellationToken);


    /// <summary>
    /// Set the path of the config file to use
    /// </summary>
    public Task<Response> SetPath(string path, CancellationToken cancellationToken = default) =>
        _rc.Post("config/setpath", path.AsJsonObject("path"), cancellationToken);
}
