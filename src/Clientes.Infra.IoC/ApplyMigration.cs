using Clientes.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Clientes.Infra.IoC
{
    public static class ApplyMigration
    {
        public static void ApplyPendingMigration(this IServiceProvider service)
        {
            using (var scope = service.CreateScope())
            {
                var _db = scope.ServiceProvider.GetRequiredService<DataContext>();

                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
        }
    }
}
