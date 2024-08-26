using Nagaira.Core.WebApi.Extensions;
using Nagaira.WebApi.Utilities.Extensions;
using System.Reflection;
using static Nagaira.WebApi.Utilities.Extensions.AsemblyExtension;

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
            services.AddCors(options =>
            {
                options.AddPolicyCors("DevelopmentCors", "http://localhost");
                options.AddPolicyCors("ProductionCors", "http://nagaira.com");
            });

            services.InstallServices<Startup>(_configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AssemblyInfo assembly = AsemblyExtension.GetAssemblyInfo(Assembly.GetEntryAssembly()!);
            string corsEnvironment = "ProductionCors";

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                corsEnvironment = "DevelopmentCors";
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{assembly.Name} {assembly.Version}");
                });
            }
            
            app.UseCors(corsEnvironment);
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", context => RootEndpointHelper.HandleRootEndpoint(context, env.IsProduction(), assembly.Name!, assembly.Version!));
                endpoints.MapControllers();
            });
        }
    }
}
