using AtivaInvestimentos.Domain.Interfaces;
using AtivaInvestimentos.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AtivaInvestimentos.API.Configuration.DependencyInjection
{
    public static class ServicesDI
    {
        public static void Register(this IServiceCollection services)
        {
            services.AddScoped<IFundoService, FundoService>();
        }
    }
}
