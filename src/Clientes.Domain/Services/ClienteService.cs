
using Clientes.Domain.Entities;
using Clientes.Domain.Interfaces.Repositories;
using Clientes.Domain.Interfaces.Services;
using Clientes.Domain.Services.Base;

namespace Clientes.Domain.Services
{
    public sealed class ClienteService : BaseService<Cliente>, IClienteService
    {
        public ClienteService(IClienteRepository clienteRepository) : base(clienteRepository)
        {
        }
    }
}
