using Nagaira.Core.WebApi;
using Nagaira.Core.WebApi.Extensions;
using Nagaira.WebApi.Utilities.Configurations;
using Nagaira.WebApi.Utilities.Extensions;
using Newtonsoft.Json;

namespace Nagaira.Template.Api.Infraestructure.Installers
{
    public class GlobalInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            string secretKeyEnconde = configuration.GetSection("Jwt")["Secret"]!;
            string issuer = configuration.GetSection("Jwt")["Issuer"];
            string audience = configuration.GetSection("Jwt")["Audience"];
            string ruta = AppDomain.CurrentDomain.BaseDirectory;

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            services.AddTransient(provider =>
            {
                LoggerHelper loggerHelper = new LoggerHelper(ruta);

                ServiceProvider serviceProvider = services.BuildServiceProvider();
                IHostApplicationLifetime lifetime = serviceProvider.GetRequiredService<IHostApplicationLifetime>();
                lifetime.ApplicationStopping.Register(loggerHelper.Dispose);

                return loggerHelper;
            });

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
