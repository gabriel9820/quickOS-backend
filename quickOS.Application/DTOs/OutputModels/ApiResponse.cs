using System.Net;

namespace quickOS.Application.DTOs.OutputModels;

public class ApiResponse<T> where T : class
{
    public bool Success { get; private set; }
    public T? Data { get; private set; }
    public int ErrorCode { get; private set; }
    public string? Message { get; private set; }
    // public IEnumerable<string> Errors { get; private set; }

    private ApiResponse(bool success, T? data, HttpStatusCode? errorCode, string? message)
    {
        Success = success;
        Data = data;
        ErrorCode = (int)errorCode.GetValueOrDefault();
        Message = message;
    }

    public static ApiResponse<T> Ok(T? data = null)
    {
        return new ApiResponse<T>(true, data, null, null);
    }

    public static ApiResponse<T> Error(HttpStatusCode errorCode, string? message = null)
    {
        return new ApiResponse<T>(false, null, errorCode, message);
    }
}
