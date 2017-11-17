using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using WebNetCore2.Models;

namespace WebNetCore2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<MySqlDbContext>(optionsBuilder =>
            {
                optionsBuilder.UseMySql(ConfigurationExtensions.GetConnectionString(this.Configuration, "SampleConnection"));
            });


            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(cfg =>
            {
                //https://wildermuth.com/2017/08/19/Two-AuthorizationSchemes-in-ASP-NET-Core-2
                //cfg.RequireHttpsMetadata = false;
                //cfg.SaveToken = true;

                //cfg.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                //{
                //    ValidIssuer = Configuration["Tokens:Issuer"],
                //    ValidAudience = Configuration["Tokens:Issuer"],
                //    IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Tokens:Key"]))
                //};

                //https://blog.markvincze.com/secure-an-asp-net-core-api-with-firebase/
                cfg.IncludeErrorDetails = true;
                cfg.Authority = "https://securetoken.google.com/prueba-2ef26";
                cfg.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = "https://securetoken.google.com/prueba-2ef26",
                    ValidateAudience = true,
                    ValidAudience = "prueba-2ef26",
                    ValidateLifetime = true,

                };
            });


            //https://docs.microsoft.com/en-us/aspnet/core/tutorials/web-api-help-pages-using-swagger?tabs=visual-studio
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info { Title = "My API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new Swashbuckle.AspNetCore.Swagger.ApiKeyScheme()
                {
                    In = "header",
                    Description = "JWT Bearer Token (ej: Bearer token)",
                    Name = "Authorization"
                });
            });

            //https://docs.microsoft.com/en-us/aspnet/core/security/cors
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                builder =>
                {
                    builder.WithOrigins("http://localhost:4200")
                    //    builder.AllowAnyOrigin(); -> para permitir todos los orígenes
                      .AllowAnyMethod()
                      .WithHeaders("accept", "content-type", "origin", "authorization");
                });
            });

            services.AddMvc();

            services.Configure<Microsoft.AspNetCore.Mvc.MvcOptions>(options =>
            {
                options.Filters.Add(new Microsoft.AspNetCore.Mvc.Cors.Internal.CorsAuthorizationFilterFactory("CorsPolicy"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.Use(async (context, next) =>
            {
                // Do work that doesn't write to the Response.
                await next.Invoke();
                // Do logging or other work that doesn't write to the Response.
            });

            app.UseMiddleware<RequestLoggingMiddleware>();

            app.UseMiddleware<ResponseLoggingMiddleware>();

            app.UseMiddleware<ErrorWrappingMiddleware>();

            app.UseMvc();
        }
    }
}
