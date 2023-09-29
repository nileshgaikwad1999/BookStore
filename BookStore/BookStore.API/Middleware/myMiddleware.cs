using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Threading.Tasks;

namespace BookStore.API.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class myMiddleware
    {
        private readonly RequestDelegate _next;

        public myMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {
                httpContext.Response.ContentType= "application/json";
                httpContext.Response.StatusCode =(int)HttpStatusCode.InternalServerError;
                await httpContext.Response.WriteAsync(
                    new
                    {
                        statusCode = httpContext.Response.StatusCode,
                        message = e.Message
                    }.ToString()
                    ); 
            }

           
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class myMiddlewareExtensions
    {
        public static IApplicationBuilder UsemyMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<myMiddleware>();
        }
    }
}
