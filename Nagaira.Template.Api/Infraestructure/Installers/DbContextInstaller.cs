using Microsoft.EntityFrameworkCore;
using Nagaira.DataLayer.Core.Extentions;
using Nagaira.Template.Api.Infraestructure.DbContexts;
using Nagaira.Template.Api.Infraestructure.DbContexts.Ecommerce;
using Nagaira.WebApi.Utilities.Configurations;

namespace Nagaira.Template.Api.Infraestructure.Installers
{
    public class DbContextInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EcommerceDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("EcommerceDb")))
                  .AddUnitOfWorkBuilder<UnitOfWorkType>(options =>
                  {
                      options.AddResolver<EcommerceDbContext>(UnitOfWorkType.Ecommerce);
                  });
        }
    }
}
