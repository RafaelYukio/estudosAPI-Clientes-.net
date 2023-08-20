using Clientes.Application.DTOs.Requests;
using Clientes.Application.DTOs.Responses;
using Clientes.Domain.Entities;

namespace Clientes.Application.Interfaces
{
    public interface IClienteAppService
    {
        Task<IEnumerable<ClienteResponse>> GetAllAsync();
        Task<IEnumerable<ClienteNomeResponse>> GetAllNomesAsync();
        Task<ClienteResponse> GetByIdAsync(int id);
        Task<ClienteResponse> InsertAsync(InsertClienteRequest insertClienteRequest);
        Task<ClienteResponse> UpdateAsync(UpdateClienteRequest updateClienteRequest, int id);
        Task RemoveAsync(int id);
    }
}
