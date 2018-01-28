using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace WebNetCore2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Todo este código está cambiado, no es el que crea la plantilla de VS, pero hace lo mismo

            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var isDevelopment = environment == EnvironmentName.Development;

            var urlToUse = string.Empty;

            if (!isDevelopment)
            {
                  urlToUse = $"http://*:{Environment.GetEnvironmentVariable("PORT")}/";

                Console.WriteLine($"Using Url: {urlToUse}");
            }


            var webHost = new WebHostBuilder()
              .UseKestrel()
              .UseContentRoot(Directory.GetCurrentDirectory())
              .ConfigureAppConfiguration((hostingContext, config) =>
              {
                  var env = hostingContext.HostingEnvironment;
                  config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
                  config.AddEnvironmentVariables();
              })
              .ConfigureLogging((hostingContext, logging) =>
              {
                  //https://docs.microsoft.com/en-us/aspnet/core/fundamentals/logging/?tabs=aspnetcore2x#how-to-add-providers

                  // Trace = 0, Debug = 1, Information = 2, Warning = 3, Error = 4, Critical = 5

                  logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                  logging.AddConsole();
                  logging.AddDebug();
              })
              .UseStartup<Startup>()
              .UseUrls(urlToUse)
              .Build();

            webHost.Run();
        }
    }
}
