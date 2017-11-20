using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebNetCore2
{
    public class ErrorWrappingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorWrappingMiddleware> _logger;

        public ErrorWrappingMiddleware(RequestDelegate next, ILogger<ErrorWrappingMiddleware> logger)
        {
            _next = next;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);                

                context.Response.StatusCode = 500;
            }

            if (!context.Response.HasStarted)
            {
                context.Response.ContentType = "application/json";

                var result = new Models.ApiResult();
                result.Severity = 0;
                result.Message = "Ocurrió un error en el servidor";
                                
                var json = JsonConvert.SerializeObject(result, new JsonSerializerSettings
                {
                //    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });

                await context.Response.WriteAsync(json);
            }
        }
    }
}
