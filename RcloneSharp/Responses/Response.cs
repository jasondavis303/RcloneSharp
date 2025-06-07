namespace RcloneSharp.Responses;

public class Response
{
    public bool Success { get; set; }

    public ErrorResponse? Error { get; set; }

    public AsyncResponse? Async { get; set; }

    public string? RequestJson { get; set; }

    public required string ResponseJson { get; set; }
}


public class Response<T> : Response
{
    public T? ResponseData { get; set; }
}
