using Clientes.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
namespace Clientes.Infra.IoC
{
    public static class DbDockerInjection
    {
        public static void AddDockerDbInjections(this IServiceCollection services,
                                                 string dbServer,
                                                 string dbName,
                                                 string dbPassword)
        {
            string connectionString = $"Server={dbServer};Database={dbName};User Id=SA;Password={dbPassword};Trust Server Certificate=true;Encrypt=False";

            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(connectionString)
            );
        }
    }
}
