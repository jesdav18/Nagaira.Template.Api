using Nagaira.Template.Api.Infraestructure.Persistence.Categories.Interfaces;
using Nagaira.Template.Api.Infraestructure.Persistence.Categories.Repositories;
using Nagaira.WebApi.Utilities.Configurations;

namespace Nagaira.Template.Api.Infraestructure.Persistence.Categories.Installers
{
    public class CategoryPersistenceInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ICategoryRepository, CategoryRepository>();
        }
    }
}
