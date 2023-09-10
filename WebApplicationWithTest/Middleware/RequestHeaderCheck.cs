using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace WebApplicationWithTest.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class RequestHeaderCheck
    {
        private readonly RequestDelegate _next;

        public RequestHeaderCheck(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Check if the required header is present
            //if (!context.Request.Headers.ContainsKey("X-Custom-Header"))
            //{
            //    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            //    await context.Response.WriteAsync("Missing required header");
            //    return;
            //}

            // Call the next middleware in the pipeline
            await _next(context);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class RequestHeaderCheckExtensions
    {
        public static IApplicationBuilder UseRequestHeaderCheckMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestHeaderCheck>();
        }
    }
}
