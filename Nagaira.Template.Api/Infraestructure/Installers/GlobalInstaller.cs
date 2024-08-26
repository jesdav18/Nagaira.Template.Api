using Nagaira.Core.WebApi;
using Nagaira.Core.WebApi.Extensions;
using Nagaira.Core.WebApi.Filters;
using Nagaira.WebApi.Utilities.Configurations;
using Nagaira.WebApi.Utilities.Extensions;
using Newtonsoft.Json;

namespace Nagaira.Template.Api.Infraestructure.Installers
{
    public class GlobalInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            services.AddTransient(provider =>
            {
                string ruta = AppDomain.CurrentDomain.BaseDirectory;

                LoggerHelper loggerHelper = new LoggerHelper(ruta);

                ServiceProvider serviceProvider = services.BuildServiceProvider();
                IHostApplicationLifetime lifetime = serviceProvider.GetRequiredService<IHostApplicationLifetime>();
                lifetime.ApplicationStopping.Register(loggerHelper.Dispose);

                return loggerHelper;
            });

            services.AddControllers(options =>
            {
                options.Filters.Add<GlobalExceptionFilter>();
            }); 
        }
    }
}
