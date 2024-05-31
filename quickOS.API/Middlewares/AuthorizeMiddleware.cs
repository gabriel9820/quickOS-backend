using System.Net;
using System.Text.Json;

namespace quickOS.API.Middlewares;

public class AuthorizeMiddleware
{
    private readonly RequestDelegate _next;

    public AuthorizeMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        await _next(context);

        if (context.Response.StatusCode == (int)HttpStatusCode.Forbidden)
        {
            context.Response.ContentType = "application/json";
            var response = new { message = "Você não tem permissão para realizar esta ação" };

            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
