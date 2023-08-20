using Clientes.Domain.Entities;
using Clientes.Domain.Interfaces.Repositories;
using Clientes.Infra.Data.Contexts;
using Clientes.Infra.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Clientes.Infra.Data.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(DataContext context) : base(context) { }

        public override async Task<Cliente> GetByIdAsync(int id) => await _DbSet.AsNoTracking().Include(cliente => cliente.Detalhes).FirstOrDefaultAsync(entity => entity.Id == id);
        public override async Task<List<Cliente>> GetAllAsync() => await _DbSet.AsNoTracking().Include(cliente => cliente.Detalhes).ToListAsync();
    }
}
