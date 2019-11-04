using AtivaInvestimentos.Infra.Repositories;
using AtivaInvestimentos.Infra.Repositories.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace AtivaInvestimentos.API.Configuration.DependencyInjection
{
    public static class RepositoriesDI
    {
        public static void Register(this IServiceCollection services)
        {
            services.AddScoped<IFundoRepository, FundoRepository>();
            services.AddScoped<IMovimentacaoRepository, MovimentacaoRepository>();
        }
    }
}
