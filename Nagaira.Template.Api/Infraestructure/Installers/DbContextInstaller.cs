using Microsoft.EntityFrameworkCore;
using Nagaira.DataLayer.Core.Extentions;
using Nagaira.Template.Api.Infraestructure.DbContexts;
using Nagaira.Template.Api.Infraestructure.DbContexts.Example;
using Nagaira.WebApi.Utilities.Configurations;

namespace Nagaira.Template.Api.Infraestructure.Installers
{
    public class DbContextInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ExampleDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("ExampleDb")))
                  .AddUnitOfWorkBuilder<UnitOfWorkType>(options =>
                  {
                      options.AddResolver<ExampleDbContext>(UnitOfWorkType.Example);
                  });
        }
    }
}
