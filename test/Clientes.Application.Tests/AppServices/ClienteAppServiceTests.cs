using Clientes.Application.AppServices;
using Clientes.Application.DTOs.Requests;
using Clientes.Application.DTOs.Responses;
using Clientes.Domain.Entities;
using Clientes.Domain.Interfaces.Services;
using Newtonsoft.Json;
using NSubstitute;

namespace Clientes.Application.Tests.AppServices
{
    public class ClienteAppServiceTests
    {
        private readonly ClienteAppService _clienteAppService;
        private readonly IClienteService _clienteService;

        public ClienteAppServiceTests()
        {
            _clienteService = Substitute.For<IClienteService>();
            _clienteAppService = new ClienteAppService(_clienteService);
        }

        [Fact]
        public async Task InsertCliente_PropriedadeEmailInvalido_ThrowsInvalidOperationException()
        {
            // Arrange
            InsertClienteRequest insertClienteRequest = new("Nome Completo", "(11) 99999-9999", "", "Endereço");

            // Act
            Func<Task> act = () => _clienteAppService.InsertAsync(insertClienteRequest);

            // Assert
            var exception = await Assert.ThrowsAsync<InvalidOperationException>(act);
            Assert.Equal("Não é possível criar Detalhes.", exception.Message);
        }

        [Fact]
        public async Task InsertCliente_PropriedadeTelefoneInvalido_ThrowsInvalidOperationException()
        {
            // Arrange
            InsertClienteRequest insertClienteRequest = new("Nome Completo", "", "email@email.com", "Endereço");

            // Act
            Func<Task> act = () => _clienteAppService.InsertAsync(insertClienteRequest);

            // Assert
            var exception = await Assert.ThrowsAsync<InvalidOperationException>(act);
            Assert.Equal("Não é possível criar Cliente.", exception.Message);
        }

        [Fact]
        public async Task InsertCliente_PropriedadesValidas_ReturnsClienteResponse()
        {
            // Arrange
            InsertClienteRequest insertClienteRequest = new("Nome Completo", "(11) 99999-9999", "email@email.com", "Endereço");
            
            Cliente cliente = new(insertClienteRequest.NomeCompleto, insertClienteRequest.Telefone);
            Detalhes detalhes = new(insertClienteRequest.Endereco, insertClienteRequest.Email);
            cliente.Detalhes = detalhes;
            cliente.Id = 1;

            var clienteResponseSerializedMock = JsonConvert.SerializeObject(new
            {
                Id = 1,
                NomeCompleto = "Nome Completo",
                Telefone = "(11) 99999-9999",
                Email = "email@email.com",
                Endereco = "Endereço"
            });

            _clienteService.InsertAsync(default).ReturnsForAnyArgs(cliente);

            // Act
            ClienteResponse clienteResponse = await _clienteAppService.InsertAsync(insertClienteRequest);

            // Assert
            var clienteResponseSerialized = JsonConvert.SerializeObject(clienteResponse);
            Assert.NotNull(clienteResponse);
            Assert.Equal(clienteResponseSerializedMock, clienteResponseSerialized);
        }
    }
}
