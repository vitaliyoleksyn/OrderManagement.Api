using Microsoft.AspNetCore.Builder;

namespace Albelli.OrderManagement.Api.Middleware
{
    public static class CustomExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder buider) =>
        buider.UseMiddleware<CustomExceptionHandlerMiddleware>();
    }
}
