using Microsoft.AspNetCore.Builder;

namespace API.Middleware
{
    public static class HttpContextMiddlewareExtensions
{
    public static IApplicationBuilder UseHttpContextMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<HttpContextMiddleware>();
    }
}
}




