using Nagaira.Template.Api.Features.Categories.Application.Services;
using Nagaira.Template.Api.Features.Categories.Application.Services.Interfaces;
using Nagaira.Template.Api.Features.Categories.Domain.Repositories;
using Nagaira.Template.Api.Features.Categories.Domain.Services;
using Nagaira.Template.Api.Features.Categories.Domain.Services.Interfaces;
using Nagaira.Template.Api.Features.Categories.Infraestructure.Mappers;
using Nagaira.Template.Api.Features.Categories.Infraestructure.Persistence;
using Nagaira.WebApi.Utilities.Configurations;

namespace Nagaira.Template.Api.Features.Categories.Infraestructure
{
    public class CategoryServiceInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ICategoryAppService, CategoryAppService>();

            services.AddTransient<ICategoryDomainService, CategoryDomainService>();

            services.AddAutoMapper(options => options.AddProfile(new CategoryMapperDto()));

            services.AddTransient<ICategoryRepository, CategoryRepository>();
        }
    }
}
