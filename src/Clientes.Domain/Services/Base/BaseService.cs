﻿using Clientes.Domain.Entities.Base;
using Clientes.Domain.Interfaces.Repositories.Base;
using Clientes.Domain.Interfaces.Services.Base;

namespace Clientes.Domain.Services.Base
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        private readonly IBaseRepository<T> _baseRepository;
        public BaseService(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync() =>
            await _baseRepository.GetAllAsync();

        public virtual async Task<T> GetByIdAsync(int id) =>
            await _baseRepository.GetByIdAsync(id);

        public virtual async Task<T> InsertAsync(T entity) =>
            await _baseRepository.InsertAsync(entity);

        public virtual async Task<T> UpdateAsync(T entity) =>
            await _baseRepository.UpdateAsync(entity);

        public virtual async Task RemoveAsync(int id) =>
            await _baseRepository.RemoveAsync(id);
    }
}
