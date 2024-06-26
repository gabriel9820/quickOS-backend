using System.Net;
using System.Text.Json;

namespace quickOS.API.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            var response = context.Response;
            response.ContentType = "application/json";

            /* handle custom exceptions status code here */
            response.StatusCode = exception switch
            {
                // MyCustomException => (int)HttpStatusCode.BadRequest, 
                _ => (int)HttpStatusCode.InternalServerError,
            };

            var options = new JsonSerializerOptions(JsonSerializerDefaults.Web)
            {
                WriteIndented = true
            };

            var message = exception.InnerException?.Message ?? exception.Message;
            var payload = JsonSerializer.Serialize(message, options);

            await response.WriteAsync(payload);
        }
    }
}
