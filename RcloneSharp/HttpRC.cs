using RcloneSharp.HttpEndpoints;
using RcloneSharp.Requests;
using RcloneSharp.Responses;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace RcloneSharp;

public class HttpRC(string host = "http://localhost:5572", string? user = null, string? password = null)
{
    internal static readonly JsonSerializerOptions JsonSerializerOps = new(JsonSerializerDefaults.Web);

    static readonly HttpClient _client = new();


    void AddAuthToRequest(HttpRequestMessage requestMessage)
    {
        if (!string.IsNullOrWhiteSpace(user))
            if (!string.IsNullOrWhiteSpace(password))
                requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes(user + ":" + password)));
    }

    static string? SerializeRequestData(HttpRequestMessage requestMessage, object? data)
    {
        string? requestJson = null;
        if (data != null)
        {
            if (data is ICustomRequestSerialization icustom)
                requestJson = JsonSerializer.Serialize(icustom.GetJsonObject(), JsonSerializerOps);
            else
                requestJson = JsonSerializer.Serialize(data, JsonSerializerOps);
            requestMessage.Content = new StringContent(requestJson, new MediaTypeHeaderValue("application/json"));
        }
        return requestJson;
    }


    internal async Task<Response> Post(string subUrl, object? data, CancellationToken cancellationToken)
    {
        HttpRequestMessage requestMessage = new(HttpMethod.Post, new Uri(new Uri(host.TrimEnd('/')), subUrl.TrimStart('/')));
        AddAuthToRequest(requestMessage);
        string? requestJson = SerializeRequestData(requestMessage, data);

        HttpResponseMessage responseMessage = await _client.SendAsync(requestMessage, completionOption: HttpCompletionOption.ResponseHeadersRead, cancellationToken: cancellationToken).ConfigureAwait(false);
        string responseJson = await responseMessage.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);

        if (responseMessage.IsSuccessStatusCode)
        {
            if (data is BaseRequest br && br.Async)
            {
                return new Response
                {
                    Success = true,
                    RequestJson = requestJson,
                    ResponseJson = responseJson,
                    Async = JsonSerializer.Deserialize<AsyncResponse>(responseJson, JsonSerializerOps)
                };
            }
            else
            {
                return new Response
                {
                    Success = true,
                    RequestJson = requestJson,
                    ResponseJson = responseJson
                };
            }
        }
        else
        {
            return new Response
            {
                RequestJson = requestJson,
                ResponseJson = responseJson,
                Error = JsonSerializer.Deserialize<ErrorResponse>(responseJson, JsonSerializerOps)
            };
        }
    }


    internal async Task<Response<T>> PostAndReturnData<T>(string subUrl, object? data, CancellationToken cancellationToken)
    {
        HttpRequestMessage requestMessage = new(HttpMethod.Post, new Uri(new Uri(host.TrimEnd('/')), subUrl.TrimStart('/')));
        AddAuthToRequest(requestMessage);
        string? requestJson = SerializeRequestData(requestMessage, data);

        HttpResponseMessage responseMessage = await _client.SendAsync(requestMessage, completionOption: HttpCompletionOption.ResponseHeadersRead, cancellationToken: cancellationToken).ConfigureAwait(false);
        string responseJson = await responseMessage.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);

        if (responseMessage.IsSuccessStatusCode)
        {
            if (data is BaseRequest br && br.Async)
            {
                return new Response<T>
                {
                    Success = true,
                    RequestJson = requestJson,
                    ResponseJson = responseJson,
                    Async = JsonSerializer.Deserialize<AsyncResponse>(responseJson, JsonSerializerOps)
                };
            }
            else
            {
                return new Response<T>
                {
                    Success = true,
                    RequestJson = requestJson,
                    ResponseJson = responseJson,
                    ResponseData = JsonSerializer.Deserialize<T>(responseJson, JsonSerializerOps)
                };
            }
        }
        else
        {
            return new Response<T>
            {
                RequestJson = requestJson,
                ResponseJson = responseJson,
                Error = JsonSerializer.Deserialize<ErrorResponse>(responseJson, JsonSerializerOps)
            };
        }
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

    //public PluginsctlEndpoints PluginsCtl => new(this);
    //Excluded - it's a GUI for rclone. This api is for building GUIs, 
    //so it's kind of beyond the scope of this library

    public RCEndpoints RC => new(this);

    public SyncEndpoints Sync => new(this);

    public VfsEndpoints Vfs => new(this);
}
