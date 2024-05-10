using Nagaira.WebApi.Utilities.Extensions;
using System.Reflection;

namespace Nagaira.Template.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.InstallServices<Startup>(_configuration);

            services.AddCors(options =>
            {
                options.AddPolicyDiunsa("DevelopmentCors");
                options.AddPolicyDiunsa("ProductionCors", "http://nagaira.com");
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var assembly = Assembly.GetEntryAssembly();
            var assemblyName = assembly?.GetName().Name;
            var version = assembly?.GetName().Version?.ToString();
            var corsEnvironment = "ProductionCors";

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                corsEnvironment = "DevelopmentCors";

                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{assemblyName} {version}");
                });
            }

            app.UseCors(corsEnvironment);
            app.UseRouting();
            app.UseAuthorization();
            
            app.ConfigureHealthCheck();

            app.UseEndpoints(endpoints =>
            {
                var ruta = AppDomain.CurrentDomain.BaseDirectory;

                endpoints.MapGet("logs", new LogEndpointHelper(ruta).HandleLogsEndpoint);
                endpoints.MapGet("/", context => RootEndpointHelper.HandleRootEndpoint(context, env.IsProduction(), assemblyName, version));
                endpoints.MapControllers();
            });

        }
    }
}
