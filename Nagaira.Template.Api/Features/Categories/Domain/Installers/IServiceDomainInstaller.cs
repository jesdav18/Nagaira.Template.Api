using Nagaira.Template.Api.Features.Categories.Domain.Interfaces;
using Nagaira.Template.Api.Features.Categories.Domain.Services;
using Nagaira.WebApi.Utilities.Configurations;

namespace Nagaira.Template.Api.Features.Categories.Domain.Installers
{
    public class IServiceDomainInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ICategoryDomainService, CategoryDomainService>();
        }
    }
}
