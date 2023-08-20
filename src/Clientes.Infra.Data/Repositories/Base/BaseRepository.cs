using Clientes.Domain.Entities.Base;
using Clientes.Domain.Interfaces.Repositories.Base;
using Clientes.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Clientes.Infra.Data.Repositories.Base
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        public readonly DbSet<T> _DbSet;
        public readonly DataContext _context;

        public BaseRepository(DataContext context)
        {
            _DbSet = context.Set<T>();
            _context = context;
        }

        public virtual async Task<T> InsertAsync(T entity)
        {
            _DbSet.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            _DbSet.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public virtual async Task<T> GetByIdAsync(int id) => await _DbSet.AsNoTracking().FirstOrDefaultAsync(entity => entity.Id == id);

        public virtual async Task<List<T>> GetAllAsync() => await _DbSet.AsNoTracking().ToListAsync();

        public virtual async Task RemoveAsync(int id)
        {
            T entity = await GetByIdAsync(id);
            _DbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
