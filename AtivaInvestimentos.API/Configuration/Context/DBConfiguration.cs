using AtivaInvestimentos.Infra.Context;
using AtivaInvestimentos.Infra.DBConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AtivaInvestimentos.API.Configuration.Context
{
    public static class DBConfiguration
    {
        public static void Register(this IServiceCollection services)
        {
            var _configuration = DatabaseConnection.ConnectionConfiguration;
            var conn = _configuration.GetConnectionString("SQLExpressConnection");
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(conn));
        }
    }
}
