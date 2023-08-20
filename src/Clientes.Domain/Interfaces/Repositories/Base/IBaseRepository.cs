using Clientes.Domain.Entities.Base;

namespace Clientes.Domain.Interfaces.Repositories.Base
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T> InsertAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
        Task RemoveAsync(int id);
    }
}
