using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace RcloneSharp;

public class HttpRC(string host = "http://localhost:5572", string? user = null, string? password=null)
{
    static readonly HttpClient _client = new();
    
    internal HttpRequestMessage BuildRequest(string subUrl, object data)
    {
        HttpRequestMessage request = new(HttpMethod.Post, new Uri(new Uri(host.TrimEnd('/')), subUrl.TrimStart('/'));

        if (!string.IsNullOrWhiteSpace(user))
            if (!string.IsNullOrWhiteSpace(password))
                request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes(user + ":" + password)));

        if(data != null)
            request.Content = new StringContent(JsonSerializer.Serialize(data), new MediaTypeHeaderValue("application/json"));

        return request;
    }

    internal async Task PostOnly(string subUrl, object data, CancellationToken cancellationToken)
    {
        HttpRequestMessage request = BuildRequest(subUrl, data);
        HttpResponseMessage response = await _client.SendAsync(request, completionOption: HttpCompletionOption.ResponseHeadersRead, cancellationToken: cancellationToken).ConfigureAwait(false);
        response.EnsureSuccessStatusCode();
    }

    internal async Task<T> PostAndGetResponse(string subUrl, object data, CancellationToken cancellationToken)
    {
        HttpRequestMessage request = BuildRequest(subUrl, data);
        HttpResponseMessage response = await _client.SendAsync(request, completionOption: HttpCompletionOption.ResponseHeadersRead, cancellationToken: cancellationToken).ConfigureAwait(false);
        response.EnsureSuccessStatusCode();
        return Task.FromResult<Task>(default?);
    }

}
