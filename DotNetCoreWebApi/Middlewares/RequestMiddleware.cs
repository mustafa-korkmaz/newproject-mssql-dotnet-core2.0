using System;
using System.IO;
using System.Threading.Tasks;
using Common;
using Dto;
using Microsoft.ApplicationInsights.AspNetCore.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Services.Logging;

namespace WebApi.Middlewares
{
    public class RequestMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogService _logService;
        // Must have constructor with this signature, otherwise exception at run time
        public RequestMiddleware(RequestDelegate next, ILogService logService)
        {
            // This is an HTTP Handler, so no need to store next
            _next = next;

            _logService = logService;
        }

        public async Task Invoke(HttpContext context)
        {
            bool hasError = false;

            string requestContent = String.Empty;
            string url = context.Request.GetUri().PathAndQuery;

            var ip = context.Request.HttpContext.Connection.RemoteIpAddress;

            Stream originalBody = context.Response.Body;

            try
            {
                requestContent = new StreamReader(context.Request.Body).ReadToEnd();
                context.Request.Body.Position = 0;

                await _next(context);

                // if you also need to log response content, use below code.

                //using (var memStream = new MemoryStream())
                //{
                //    context.Response.Body = memStream;

                //    await _next(context);

                //    memStream.Position = 0;

                //    string responseContent = new StreamReader(memStream).ReadToEnd();

                //    memStream.Position = 0;
                //    await memStream.CopyToAsync(originalBody);
                //}

            }
            catch (Exception exc)
            {
                hasError = true;
                context.Response.Clear();
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync(ErrorMessage.ApplicationExceptionMessage);

                //log service exc
                _logService.LogException(exc);

            }
            finally
            {
                if (!hasError)
                {
                    context.Response.Body = originalBody;
                }

                ProcessMessageAsync(context.Response.StatusCode, requestContent, url, ip?.ToString());
            }
        }

        /// <summary>
        /// saves req and resp async
        /// </summary>
        /// <param name="responseStatusCode"></param>
        /// <param name="requestContent"></param>
        /// <param name="url"></param>
        /// <param name="ip"></param>
        private void ProcessMessageAsync(int responseStatusCode, string requestContent, string url, string ip)
        {
            //trim requestContent as max 500 char variable
            var content = string.IsNullOrEmpty(requestContent)
                ? null
                : requestContent.Length >= 500 ? requestContent.Substring(0, 500) : requestContent;

            var requestLog = new RequestLog
            {
                Ip = ip,
                HttpResponseCode = responseStatusCode,
                RequestContent = content,
                Uri = url
            };

            _logService.LogRequest(requestLog);
        }

    }

    public static class RequestMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestMiddleware>();
        }
    }

}
