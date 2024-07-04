using System.Net;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

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

            response.StatusCode = exception switch
            {
                // MyCustomException => (int)HttpStatusCode.BadRequest, 
                _ => (int)HttpStatusCode.InternalServerError,
            };

            var message = exception switch
            {
                DbUpdateException ex when ex.InnerException != null && ex.InnerException.Message.Contains("23503:") => "Este registro está sendo usado em outros lançamentos",
                _ => exception.InnerException?.Message ?? exception.Message,
            };

            var options = new JsonSerializerOptions(JsonSerializerDefaults.Web)
            {
                WriteIndented = true
            };

            var payload = JsonSerializer.Serialize(message, options);

            await response.WriteAsync(payload);
        }
    }
}
