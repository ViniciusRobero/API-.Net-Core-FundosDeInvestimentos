using Microsoft.Extensions.Configuration;
using System.IO;
using System.Reflection;

namespace AtivaInvestimentos.Infra.DBConfiguration
{
    public class DatabaseConnection
    {
        public static IConfiguration ConnectionConfiguration
        {
            get
            {
                var path = $"{Directory.GetParent(Assembly.GetEntryAssembly().Location)}";
                return new ConfigurationBuilder()
                    .SetBasePath(path)
                    .AddJsonFile("appsettings.json")
                    .Build();
            }
        }
    }
}
