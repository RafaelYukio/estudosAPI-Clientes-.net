using Clientes.Application.DTOs.Requests;
using Clientes.Application.DTOs.Responses;
using Clientes.Application.Interfaces;
using Clientes.Domain.Entities;
using Clientes.Domain.Interfaces.Services;

namespace Clientes.Application.AppServices
{
    public class ClienteAppService : IClienteAppService
    {
        private readonly IClienteService _clienteService;

        public ClienteAppService(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public async Task<IEnumerable<ClienteResponse>> GetAllAsync()
        {
            IEnumerable<Cliente> clientes = await _clienteService.GetAllAsync();
            return clientes.Select(ConverterParaClienteResponse);
        }

        public async Task<IEnumerable<ClienteNomeResponse>> GetAllNomesAsync()
        {
            IEnumerable<Cliente> clientes = await _clienteService.GetAllAsync();
            return clientes.Select(ConverterParaClienteNomeResponse);
        }

        public async Task<ClienteResponse> GetByIdAsync(int id) => ConverterParaClienteResponse(await _clienteService.GetByIdAsync(id));

        public async Task<ClienteResponse> InsertAsync(InsertClienteRequest insertClienteRequest) =>
            ConverterParaClienteResponse(await _clienteService.InsertAsync(insertClienteRequest.ConverterParaEntidade()));

        public async Task<ClienteResponse> UpdateAsync(UpdateClienteRequest updateClienteRequest, int id) =>
            ConverterParaClienteResponse(await _clienteService.UpdateAsync(updateClienteRequest.ConverterParaEntidade(id)));

        public async Task RemoveAsync(int id) =>
            await _clienteService.RemoveAsync(id);

        private ClienteResponse ConverterParaClienteResponse(Cliente cliente) {
            if(cliente != null) return new ClienteResponse(cliente.Id,
                                                           cliente.NomeCompleto,
                                                           cliente.Telefone,
                                                           cliente.Detalhes.Email,
                                                           cliente.Detalhes.Endereco);
            return null;
        } 

        private ClienteNomeResponse ConverterParaClienteNomeResponse(Cliente cliente) => new ClienteNomeResponse(cliente.Id,
                                                                                                                 cliente.NomeCompleto);

    }
}
