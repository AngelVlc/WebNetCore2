using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebNetCore2.Exceptions;

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
            catch (InfoException infoEx)
            {
                _logger.LogInformation(infoEx.Message);
                SetResponseInfo(context, 200);
                await context.Response.WriteAsync(GetJsonResponse(1, infoEx.Message));
            }
            catch (WarningException warnEx)
            {
                _logger.LogInformation(warnEx.Message);
                SetResponseInfo(context, 200);
                await context.Response.WriteAsync(GetJsonResponse(2, warnEx.Message));
            }
            catch (ErrorException errorEx)
            {
                _logger.LogError(errorEx.Message);
                SetResponseInfo(context, 200);
                await context.Response.WriteAsync(GetJsonResponse(3, errorEx.Message));
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);
                SetResponseInfo(context, 500);
                await context.Response.WriteAsync(GetJsonResponse(0, "Ocurrió un error en el servidor"));
            }
        }

        private void SetResponseInfo(HttpContext context, int statusCode)
        {
            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";
        }

        private string GetJsonResponse(int severity, string message)
        {
            var result = new Models.ApiResult();
            result.Severity = severity;
            result.Message = message;

            var json = JsonConvert.SerializeObject(result, new JsonSerializerSettings
            {
                //    ContractResolver = new CamelCasePropertyNamesContractResolver()
            });

            return json;
        }
    }
}
