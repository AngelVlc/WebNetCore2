using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using WebNetCore2.Models;

namespace WebNetCore2
{
    public class ResponseLoggingMiddleware
    {

        private readonly RequestDelegate _next;
        private readonly ILogger<ResponseLoggingMiddleware> _logger;

        public ResponseLoggingMiddleware(RequestDelegate next, ILogger<ResponseLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            var originalBodyStream = context.Response.Body;

            var newBodyStream = new MemoryStream();
            context.Response.Body = newBodyStream;

            await _next(context);

            newBodyStream.Seek(0, SeekOrigin.Begin);
            var responseJsonBody = new StreamReader(newBodyStream).ReadToEnd();

            if (context.Response.StatusCode == 200)
            {
                var result = Newtonsoft.Json.JsonConvert.DeserializeObject(responseJsonBody);

                var apiResult = new ApiResult()
                {
                    Data = result
                };

                var jsonApiResult = Newtonsoft.Json.JsonConvert.SerializeObject(apiResult);

                _logger.LogTrace($"RESPONSE HttpMethod: {context.Request.Method}, Path: {context.Request.Path}: { jsonApiResult}");

                context.Response.Body = originalBodyStream;

                await context.Response.WriteAsync(jsonApiResult);
            }
            else
            {                
                newBodyStream.Seek(0, SeekOrigin.Begin);

                await newBodyStream.CopyToAsync(originalBodyStream);
            }            
        }
    }
}
