using System.Net;

namespace quickOS.Application.DTOs.OutputModels;

public class ApiResponse
{
    public bool Success { get; private set; }
    public int ErrorCode { get; private set; }
    public string? ErrorMessage { get; private set; }

    protected ApiResponse(bool success, HttpStatusCode? errorCode, string? errorMessage)
    {
        Success = success;
        ErrorCode = (int)errorCode.GetValueOrDefault();
        ErrorMessage = errorMessage;
    }

    public static ApiResponse Ok()
    {
        return new ApiResponse(true, null, null);
    }

    public static ApiResponse Error(HttpStatusCode errorCode, string? errorMessage = null)
    {
        return new ApiResponse(false, errorCode, errorMessage);
    }
}

public class ApiResponse<T> : ApiResponse where T : class
{
    public T? Data { get; private set; }

    private ApiResponse(bool success, T? data, HttpStatusCode? errorCode, string? errorMessage) : base(success, errorCode, errorMessage)
    {
        Data = data;
    }

    public static ApiResponse<T> Ok(T? data = null)
    {
        return new ApiResponse<T>(true, data, null, null);
    }

    public static new ApiResponse<T> Error(HttpStatusCode errorCode, string? errorMessage = null)
    {
        return new ApiResponse<T>(false, null, errorCode, errorMessage);
    }
}
