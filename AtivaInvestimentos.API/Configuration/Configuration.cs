using AtivaInvestimentos.API.Configuration.Context;
using AtivaInvestimentos.API.Configuration.Cors;
using AtivaInvestimentos.API.Configuration.DependencyInjection;
using AtivaInvestimentos.API.Configuration.Swagger;
using Microsoft.Extensions.DependencyInjection;

namespace AtivaInvestimentos.API.Configuration
{
    public static class Configuration
    {
        public static void AddConfiguration(this IServiceCollection service)
        {
            DBConfiguration.Register(service);
            RepositoriesDI.Register(service);
            ServicesDI.Register(service);
            CorsConfiguration.RegisterCors(service);
            SwaggerConfiguration.RegisterSwagger(service);
        }
    }
}
