using Nagaira.Core.WebApi.Extensions;
using Nagaira.WebApi.Utilities.Configurations;
using Nagaira.WebApi.Utilities.Extensions;
using System.Reflection;
using static Nagaira.WebApi.Utilities.Extensions.AsemblyExtension;

namespace Nagaira.Template.Api.Infraestructure.Installers
{
    public class ThirdPartyInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            AssemblyInfo assembly = AsemblyExtension.GetAssemblyInfo(Assembly.GetEntryAssembly()!);        
            SwaggerConfig.ConfigureSwaggerGen(services, assembly.Name!, assembly.Version!);
            services.AddHealthChecks();
        }
    }
}
