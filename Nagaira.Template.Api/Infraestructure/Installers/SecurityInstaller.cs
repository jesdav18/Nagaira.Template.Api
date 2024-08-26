using Nagaira.Core.WebApi;
using Nagaira.Core.WebApi.Extensions;
using Nagaira.WebApi.Utilities.Configurations;

namespace Nagaira.Template.Api.Infraestructure.Installers
{
    public class SecurityInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            string secretKeyEnconde = configuration.GetSection("Jwt")["Secret"]!;
            string issuer = configuration.GetSection("Jwt")["Issuer"]!;
            string audience = configuration.GetSection("Jwt")["Audience"]!;

            List<JwtAuthenticationOptions> authenticationOptions = new List<JwtAuthenticationOptions>
{
                new JwtAuthenticationOptions
                {
                    SchemaName = "JwtNagaira",
                    SecretKey = secretKeyEnconde,
                    ValidIssuer = issuer,
                    Audience = audience
                }
            };

            services.AddJwtAuthentication(authenticationOptions);
        }
    }
}
