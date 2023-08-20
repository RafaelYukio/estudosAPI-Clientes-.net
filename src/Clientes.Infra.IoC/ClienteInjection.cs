using Clientes.Application.AppServices;
using Clientes.Application.Interfaces;
using Clientes.Domain.Interfaces.Repositories;
using Clientes.Domain.Interfaces.Services;
using Clientes.Domain.Services;
using Clientes.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
namespace Clientes.Infra.IoC
{
    public static class ClienteInjection
    {
        public static void AddClienteInjections(this IServiceCollection service)
        {
            service.AddScoped<IClienteAppService, ClienteAppService>();
            service.AddScoped<IClienteService, ClienteService>();
            service.AddScoped<IClienteRepository, ClienteRepository>();
        }
    }
}
