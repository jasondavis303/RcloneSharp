using RcloneSharp.Responses;
using System.Text.Json.Nodes;

namespace RcloneSharp.HttpEndpoints;

public class OptionsEndpoints
{
    readonly HttpRC _rc;

    internal OptionsEndpoints(HttpRC rc) => _rc = rc;


    /// <summary>
    /// List all the option blocks
    /// </summary>
    public Task<Response<List<string>>> Blocks(CancellationToken cancellationToken) =>
        _rc.PostAndReturnDataFlattened<List<string>>("options/blocks", null, "options", cancellationToken);

    /// <summary>
    /// Returns an object where keys are option block names and values are an object with the current option values in.
    /// </summary>
    public Task<Response<JsonObject>> Get(string? blocks = null, CancellationToken cancellationToken = default) =>
        _rc.PostAndReturnData<JsonObject>("options/get", blocks.AsJsonObject("blocks"), cancellationToken);

    /// <summary>
    /// Returns an object where keys are option block names and values are an array of objects with info about each options.
    /// </summary>
    public Task<Response<JsonObject>> Info(string? blocks = null, CancellationToken cancellationToken = default) =>
        _rc.PostAndReturnData<JsonObject>("options/info", blocks.AsJsonObject("blocks"), cancellationToken);

    /// <summary>
    /// Returns an object with the keys "config" and "filter". The "config" key contains the local config and the "filter" key contains the local filters.
    /// 
    /// This call is mostly useful for seeing if _config and _filter passing is working.
    /// </summary>
    public Task<Response> Local(object? request = null, CancellationToken cancellationToken = default) =>
        _rc.Post("options/local", request, cancellationToken);


    public Task<Response> Set(string key, object value, CancellationToken cancellationToken = default)
    {
        JsonObject? request;
        if (value is string stringValue)
            request = stringValue.AsJsonObject(key);
        else if (value is int intValue)
            request = intValue.AsJsonObject(key);
        else if (value is bool boolValue)
            request = boolValue.AsJsonObject(key);
        else
            throw new Exception("Unknown value type");

        return _rc.Post("options/set", request, cancellationToken);
    }
}
