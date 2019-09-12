using AuthDemo.Identity.Jwt.Middleware;
using Microsoft.AspNetCore.Builder;

namespace AuthDemo.Identity.Jwt.Extensions
{
    public static class SecureJwtMiddlewareExtensions
    {
        public static IApplicationBuilder UseSecureJwt(this IApplicationBuilder builder) => builder.UseMiddleware<SecureJwtMiddleware>();
    }
}
