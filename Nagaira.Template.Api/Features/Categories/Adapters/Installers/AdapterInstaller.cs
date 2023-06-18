using Nagaira.Template.Api.Features.Categories.Adapters.Mappers;
using Nagaira.WebApi.Utilities.Configurations;

namespace Nagaira.Template.Api.Features.Categories.Adapters.Installers
{
    public class AdapterInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(options => options.AddProfile(new CategoryMapperDto()));
        }
    }
}
