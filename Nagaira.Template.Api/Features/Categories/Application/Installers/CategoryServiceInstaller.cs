using Nagaira.Template.Api.Features.Categories.Application.Interfaces;
using Nagaira.Template.Api.Features.Categories.Application.Services;
using Nagaira.WebApi.Utilities.Configurations;

namespace Nagaira.Template.Api.Features.Categories.Application.Installers
{
    public class CategoryServiceInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ICategoryAppService, CategoryAppService>();
        }
    }
}
