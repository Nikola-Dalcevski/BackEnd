using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BicycleBuyingGuide.Api.Middlewares
{
    public class ErrorHandelingMiddelware
    {
        private readonly RequestDelegate _next;

        public ErrorHandelingMiddelware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (ArgumentException ex)
            {

                await HandleExceptionAsync(httpContext, ex);
            }
        }


        //TODO: fix handler with custom exception class
        private async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            if(ex is ArgumentException)
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await httpContext.Response.WriteAsync(ex.Message);
                return;
            }

            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        }
    }
}
