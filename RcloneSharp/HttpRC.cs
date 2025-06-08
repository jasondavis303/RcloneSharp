using RcloneSharp.HttpEndpoints;
using RcloneSharp.Requests;
using RcloneSharp.Responses;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace RcloneSharp;

public class HttpRC(string host = "http://localhost:5572", string? user = null, string? password = null)
{
    internal static readonly JsonSerializerOptions JsonSerializerOps = new(JsonSerializerDefaults.Web);

    static readonly HttpClient _internalClient = new();

    /// <summary>
    /// Helper to launch simple rclone daemons.
    /// </summary>
    public static Process LaunchRCD(RCDLaunchInfo launchInfo) =>
        Process.Start(launchInfo.RcloneExe, launchInfo.BuildArgs());


    /// <summary>
    /// Optional: If you need to cusomize the <see cref="HttpClient"/> (e.g. using client certificates), you can specify a client to use here.
    /// Otherwise the default internal <see cref="HttpClient"/> will be used.
    /// </summary>
    public HttpClient? CustomHttpClient { get; set; }


    internal async Task<Response> Post(string subUrl, object? data, CancellationToken cancellationToken)
    {
        using HttpRequestMessage requestMessage = new(HttpMethod.Post, new Uri(new Uri(host.TrimEnd('/')), subUrl.TrimStart('/')));

        if (!string.IsNullOrWhiteSpace(user))
            if (!string.IsNullOrWhiteSpace(password))
                requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes(user + ":" + password)));


        string? requestJson = null;
        if (data != null)
        {
            if (data is ICustomRequestSerialization icustom)
                requestJson = JsonSerializer.Serialize(icustom.GetJsonObject(), JsonSerializerOps);
            else
                requestJson = JsonSerializer.Serialize(data, JsonSerializerOps);
            requestMessage.Content = new StringContent(requestJson, new MediaTypeHeaderValue("application/json"));
        }

        using HttpResponseMessage responseMessage = await (CustomHttpClient ?? _internalClient).SendAsync(requestMessage, completionOption: HttpCompletionOption.ResponseHeadersRead, cancellationToken: cancellationToken).ConfigureAwait(false);
        string responseJson = await responseMessage.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);

        return new Response
        {
            Success = responseMessage.IsSuccessStatusCode,
            RequestJson = requestJson,
            ResponseJson = responseJson,
            Async = responseMessage.IsSuccessStatusCode ? JsonSerializer.Deserialize<AsyncResponse>(responseJson, JsonSerializerOps) : null,
            Error = responseMessage.IsSuccessStatusCode ? null : JsonSerializer.Deserialize<ErrorResponse>(responseJson, JsonSerializerOps)
        };
    }


    internal async Task<Response<T>> PostAndReturnData<T>(string subUrl, object? data, CancellationToken cancellationToken)
    {
        Response response = await Post(subUrl, data, cancellationToken).ConfigureAwait(false);
        return new Response<T>
        {
            Async = response.Async,
            Error = response.Error,
            RequestJson = response.RequestJson,
            ResponseData = response.Success ? JsonSerializer.Deserialize<T>(response.ResponseJson, JsonSerializerOps) : default,
            ResponseJson = response.ResponseJson,
            Success = response.Success
        };
    }


    internal async Task<Response<T>> PostAndReturnDataFlattened<T>(string subUrl, object? data, string name, CancellationToken cancellationToken)
    {
        Response<JsonObject> response = await PostAndReturnData<JsonObject>(subUrl, data, cancellationToken).ConfigureAwait(false);
        return new Response<T>
        {
            Success = response.Success,
            RequestJson = response.RequestJson,
            ResponseJson = response.ResponseJson,
            ResponseData = response.Success ? JsonSerializer.Deserialize<T>(response.ResponseData![name], JsonSerializerOps) : default,
            Error = response.Error
        };
    }





    public BackendEndpoints Backend => new(this);

    public ConfigEndpoints Config => new(this);

    public CoreEndpoints Core => new(this);


    //public DebugEndpoints Debug => new(this);
    //Excluded - beyond the intended use cope of this library


    public FsCacheEndpoints FsCache => new(this);

    public JobEndpoints Job => new(this);

    public MountEndpoints Mount => new(this);

    public OperationsEndpoints Operations => new(this);

    //public PluginsCtlEndpoints PluginsCtl => new(this);
    //Excluded - it's a GUI for rclone. This api is for building GUIs, 
    //so it's kind of beyond the scope of this library

    public RCEndpoints RC => new(this);

    public SyncEndpoints Sync => new(this);

    public VfsEndpoints Vfs => new(this);
}
