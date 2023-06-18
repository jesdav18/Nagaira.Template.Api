using Microsoft.OpenApi.Models;
using Nagaira.WebApi.Utilities.Configurations;
using System.Reflection;

namespace Nagaira.Template.Api.Infraestructure.Installers
{
    public class ThirdPartyInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            var assembly = Assembly.GetEntryAssembly();
            var assemblyName = assembly?.GetName().Name;
            var version = assembly?.GetName().Version?.ToString();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = assemblyName, Version = version });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = $"Bienvenido a {assemblyName} | Ingresa un Bearer Token",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT"

                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer" }
                        }, new List<string>()
                    }
                });
            });
        }
    }
}
