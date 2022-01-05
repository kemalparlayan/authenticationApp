using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Options;
using authenticationApp.Models;
using authenticationApp.Services;
using System.IO;
using System.Reflection;

namespace authenticationApp
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.Configure<AuthenticationAppDBSetings>(Configuration.GetSection(nameof(AuthenticationAppDBSetings)));
            services.AddSingleton<IAuthenticationAppDBSetings>(sp => sp.GetRequiredService<IOptions<AuthenticationAppDBSetings>>().Value);
            services.AddSingleton<AuthenticationService>();

            services.AddSwaggerGen(c =>
           {
               string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
               string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
               c.IncludeXmlComments(xmlPath);
               c.SwaggerDoc("AuthenticationApp", new OpenApiInfo
               {
                   Title = "AuthenticationApp on ASP.NET Core",
                   Version = "1.0.0",
                   Description = "AuthenticationApp on (ASP.NET Core 3.1)",
                   Contact = new OpenApiContact()
                   {
                       Name = "AuthenticationApp - Kemal Parlayan",
                       Url = new Uri("http://kemalparlayan.com"),
                       Email = "parlayankemal@gmail.com"
                   },
                   TermsOfService = new Uri("http://swagger.io/terms/"),
                   License = new OpenApiLicense()
                   {
                       Name = "My License",
                       Url = new Uri("http://www.example.com")
                   }
               });
           });
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger()
            .UseSwaggerUI(c =>
                {
                    //TODO: Either use the SwaggerGen generated Swagger contract (generated from C# classes)
                    c.SwaggerEndpoint("/swagger/AuthenticationApp/swagger.json", "AuthenticationApp");

                    //TODO: Or alternatively use the original Swagger contract that's included in the static files
                    // c.SwaggerEndpoint("/swagger-original.json", "Swagger Petstore Original");
                });
        }
    }
}
