using Microsoft.Extensions.DependencyInjection;

namespace AtivaInvestimentos.API.Configuration.Cors
{
    public static class CorsConfiguration
    {
        public static void RegisterCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("origins",
                builder =>
                {
                    builder.AllowAnyMethod()
                    .SetIsOriginAllowed((host) => true)
                    .AllowCredentials()
                    .AllowAnyHeader();
                });
            });
        }
    }
}
