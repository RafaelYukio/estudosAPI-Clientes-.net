using Clientes.Application.DTOs.Requests;
using Clientes.Application.DTOs.Responses;
using Clientes.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Clientes.API.Controllers
{
    [Route("api/clientes")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteAppService _clienteAppService;

        public ClientesController(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteResponse>>> GetAllClientes() =>
            Ok(await _clienteAppService.GetAllAsync());

        [HttpGet("nomes")]
        public async Task<ActionResult<IEnumerable<ClienteNomeResponse>>> GetAllClientesNomes() =>
            Ok(await _clienteAppService.GetAllNomesAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteResponse>> GetClienteById(int id)
        {
            ClienteResponse clienteResponse = await _clienteAppService.GetByIdAsync(id);
            if (clienteResponse != null) return Ok(clienteResponse);

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<ClienteResponse>> InsertCliente(InsertClienteRequest insertClienteRequest)
        {
            ClienteResponse clienteResponse = await _clienteAppService.InsertAsync(insertClienteRequest);
            return CreatedAtAction(nameof(GetClienteById), new { id = clienteResponse.Id }, clienteResponse);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ClienteResponse>> UpdateCliente(int id, UpdateClienteRequest updateClienteRequest)
        {
            ClienteResponse clienteResponse = await _clienteAppService.UpdateAsync(updateClienteRequest, id);
            if (clienteResponse != null) return Ok(clienteResponse);

            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveCliente(int id)
        {
            await _clienteAppService.RemoveAsync(id);
            return NoContent();
        }
    }
}
