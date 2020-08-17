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
using Emails.Api.Extensions;
using Emails.App;

namespace Emails.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        private string MyAllowSpecificOrigins = "CorsPolicy";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // services.AddControllers().AddNewtonsoftJson(options =>
            // {
            //     options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            // });

            MyAllowSpecificOrigins = Configuration.GetValue<string>("Cors:PolicyName");
            services.ConfigureCors(Configuration);

            services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));

            // services.AddSwaggerGen(c =>
            // {
            //     c.SwaggerDoc("v1", new OpenApiInfo
            //     {
            //         Version = "v1",
            //         Title = "Emails Api",
            //         Description = "A simple API to handle emails",
            //         Contact = new OpenApiContact
            //         {
            //             Name = "Sean Rafferty",
            //             Email = "",
            //             Url = new Uri("")
            //         }
            //     });

            //     // var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            //     // var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            //     // c.IncludeXmlComments(xmlPath);
            // });

            services.AddEmailApplication(Configuration);

            services.AddHealthChecks();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseCors(MyAllowSpecificOrigins);

            // app.UseSwagger();
            // app.UseSwaggerUI(c =>
            // {
            //     c.SwaggerEndpoint("/swagger/v1/swagger.json", "Emails API V1");
            //     c.RoutePrefix = string.Empty;
            // });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });
        }
    }
}
