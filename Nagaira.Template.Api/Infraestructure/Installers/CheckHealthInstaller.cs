using Nagaira.Template.Api.Infraestructure.Checks;
using Nagaira.WebApi.Utilities.Configurations;

namespace Nagaira.Template.Api.Infraestructure.Installers
{
    public class CheckHealthInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks();

            services.AddHealthChecks()
               .AddCheck("Chequeo EcommerceDb", new HealthCheckEcommerceDb(configuration.GetConnectionString("EcommerceDb")!));
        }
    }
}
