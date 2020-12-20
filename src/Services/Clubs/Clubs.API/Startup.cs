using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clubs.API.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Clubs.Infrastructure;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Clubs.Application;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Clubs.API.Extensions.HealthChecks;
using Microsoft.AspNetCore.Http;

namespace Clubs.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }
        private string MyAllowSpecificOrigins = "CorsPolicy";
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // The following line enables Application Insights telemetry collection.
            services.AddApplicationInsightsTelemetry();

            MyAllowSpecificOrigins = Configuration.GetValue<string>("Cors:PolicyName");
            services.ConfigureCors(Configuration);

            services.AddApplication(Configuration);

            //services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));

            services.ConfigureDbContext(Configuration);

            services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.Authority = "https://securetoken.google.com/cleanclubs-da2bc";
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = "https://securetoken.google.com/cleanclubs-da2bc",
                    ValidateAudience = true,
                    ValidAudience = "cleanclubs-da2bc",
                    ValidateLifetime = true
                };
            });

            services.AddHttpContextAccessor();


            services.AddControllers(o =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                o.Filters.Add(new AuthorizeFilter(policy));
            }).AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            services.AddHealthChecks().AddDbContextCheck<ClubsContext>();

            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "Clubs API", Version = "v1" }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, TelemetryConfiguration configuration)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
#if DEBUG
                configuration.DisableTelemetry = true;
#endif
            }

            app.UseHsts();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            //To serve the Swagger UI at the app's root (http://localhost:<port>/), set the RoutePrefix property to an empty string:
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Clubs API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/quickHealth", new HealthCheckOptions(){
                    Predicate = _ => false
                });
                endpoints.MapHealthChecks("/health", new HealthCheckOptions{
                    ResponseWriter = async (context, report) =>
                    {
                        context.Response.ContentType = "application/json";
                        var response = new HealthCheckResponse{
                            Status = report.Status.ToString(),
                            Checks = report.Entries.Select(x => new HealthCheck{
                                Component = x.Key,
                                Status = x.Value.Status.ToString(),
                                Description = x.Value.Description
                            }),
                            Duration = report.TotalDuration
                        };
                        await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
                    }
                });
            });
        }
    }
}
