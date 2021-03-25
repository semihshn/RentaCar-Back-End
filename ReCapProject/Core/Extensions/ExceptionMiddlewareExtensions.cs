using Microsoft.AspNetCore.Builder;

namespace Core.Extensions
{
	public static class ExceptionMiddlewareExtensions//Kendi Middleware'ımızı yazıyoruz ve startup.cs ekliyoruz
    {
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();//Asıl middleware kodlarımız ExceptionMiddleware içerisinde  
        }
    }
}
