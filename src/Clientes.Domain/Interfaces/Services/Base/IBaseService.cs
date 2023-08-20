using Clientes.Domain.Entities.Base;

namespace Clientes.Domain.Interfaces.Services.Base
{
    public interface IBaseService<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> InsertAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task RemoveAsync(int id);
    }
}
