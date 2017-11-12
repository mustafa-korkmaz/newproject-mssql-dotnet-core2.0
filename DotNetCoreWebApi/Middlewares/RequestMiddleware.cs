using System;
using System.IO;
using System.Threading.Tasks;
using Dto;
using Microsoft.ApplicationInsights.AspNetCore.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace WebApi.Middlewares
{
    public class RequestMiddleware
    {
        private readonly RequestDelegate _next;
        // Must have constructor with this signature, otherwise exception at run time
        public RequestMiddleware(RequestDelegate next)
        {
            // This is an HTTP Handler, so no need to store next
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            Stream originalBody = context.Response.Body;

            try
            {
                var requestContent = new StreamReader(context.Request.Body).ReadToEnd();
                context.Request.Body.Position = 0;

                await _next(context);

                string pathAndQuery = context.Request.GetUri().PathAndQuery;
                
                //50 chars is enough to recognize which url has been passed
                var url = pathAndQuery.Length >= 49 ? pathAndQuery.Substring(0, 49) : pathAndQuery;


                ProcessMessageAsync(context.Response.StatusCode,requestContent,url);

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
            finally
            {
                context.Response.Body = originalBody;
            }
        }

        /// <summary>
        /// saves req and resp async
        /// </summary>
        /// <param name="responseStatusCode"></param>
        /// <param name="requestContent"></param>
        /// <param name="url"></param>
        private void ProcessMessageAsync(int responseStatusCode, string requestContent, string url)
        {
            //trim requestContent as max 500 char variable
            var content = string.IsNullOrEmpty(requestContent)
                ? null
                : requestContent.Length >= 500 ? requestContent.Substring(0, 500) : requestContent;

            var requestLog = new RequestLog
            {
                Ip = "localhost", //Statics.GetIp()
                HttpResponseCode = responseStatusCode,
                RequestContent = content,
                Uri = url,
                CreatedAt = DateTime.Now//Statics.GetTurkeyCurrentDateTime()
            };

            //todo: log req & resp
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
