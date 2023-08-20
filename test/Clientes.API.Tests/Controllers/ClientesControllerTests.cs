using Clientes.API.Controllers;
using Clientes.Application.DTOs.Requests;
using Clientes.Application.Interfaces;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using NSubstitute;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text;

namespace Clientes.API.Tests.Controllers
{
    public class ClientesControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly ClientesController _clientesController;
        private readonly IClienteAppService _clientesAppService;

        private readonly WebApplicationFactory<Program> _factory;

        public ClientesControllerTests(WebApplicationFactory<Program> factory)
        {
            _clientesAppService = Substitute.For<IClienteAppService>();
            _clientesController = new ClientesController(_clientesAppService);
            _factory = factory;
        }

        private IList<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, validationContext, validationResults, true);
            return validationResults;
        }

        [Fact]
        // Teste unitário
        // Uso do método ValidateModel:
        // https://stackoverflow.com/questions/57675737/how-i-can-test-my-data-annotation-field-in-core-web-api
        public async Task InsertCliente_PropriedadeEmailInvalido_ThrowsModelValidationError()
        {
            // Arrange
            InsertClienteRequest insertClienteRequest = new("Nome Completo", "(11) 99999-9999", "email-inválido", "Endereço");

            // Act
            var modelValidationErrors = ValidateModel(insertClienteRequest);

            // Assert
            Assert.True(modelValidationErrors.Count == 1);
            Assert.True(modelValidationErrors.Where(x => x.ErrorMessage.Contains("Email é inválido")).Count() > 0);
        }

        [Fact]
        public async Task InsertCliente_PropriedadeTelefoneInvalida_ThrowsModelValidationError()
        {
            // Arrange
            InsertClienteRequest insertClienteRequest = new("Nome Completo", "", "email@email.com", "Endereço");

            // Act
            var modelValidationErrors = ValidateModel(insertClienteRequest);

            // Assert
            Assert.True(modelValidationErrors.Count == 1);
            Assert.True(modelValidationErrors.Where(x => x.ErrorMessage.Contains("Telefone é obrigatório")).Count() > 0);
        }

        [Fact]
        public async Task InsertCliente_PropriedadeValidas_ValidaModel()
        {
            // Arrange
            InsertClienteRequest insertClienteRequest = new("Nome Completo", "(11) 99999-9999", "email@email.com", "Endereço");

            // Act
            var modelValidationErrors = ValidateModel(insertClienteRequest);

            // Assert
            Assert.True(modelValidationErrors.Count == 0);
        }

        [Fact(Skip = "Teste de Integração, adicionando dados na tabela")]
        // Teste de integração
        // Utilizando o pacote Microsoft.AspNetCore.Mvc.Testing:
        // https://learn.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-7.0
        // https://stackoverflow.com/questions/52842294/how-do-i-unit-test-model-validation-in-controllers-decorated-with-apicontroller
        public async Task InsertCliente_PropriedadeEmailInvalido_BadRequest()
        {
            // Arrange
            var client = _factory.CreateClient();
            InsertClienteRequest insertClienteRequest = new("Nome Completo", "(11) 99999-9999", "email-inválido", "Endereço");
            var json = JsonConvert.SerializeObject(insertClienteRequest);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Act
            var result = await client.PostAsync("api/clientes", content);

            // Assert
            Assert.Equal((int)HttpStatusCode.BadRequest, (int)result.StatusCode);
        }

        [Fact(Skip = "Teste de Integração, adicionando dados na tabela")]
        public async Task InsertCliente_PropriedadeTelefoneInvalida_BadRequest()
        {
            // Arrange
            var client = _factory.CreateClient();
            InsertClienteRequest insertClienteRequest = new("Nome Completo", "", "email@email.com", "Endereço");
            var json = JsonConvert.SerializeObject(insertClienteRequest);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Act
            var result = await client.PostAsync("api/clientes", content);

            // Assert
            Assert.Equal((int)HttpStatusCode.BadRequest, (int)result.StatusCode);
        }

        [Fact(Skip = "Teste de Integração, adicionando dados na tabela")]
        public async Task InsertCliente_PropriedadeValidas_Created()
        {
            // Arrange
            var client = _factory.CreateClient();
            InsertClienteRequest insertClienteRequest = new("Nome Completo", "(11) 99999-9999", "email@email.com", "Endereço");
            var json = JsonConvert.SerializeObject(insertClienteRequest);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Act
            var result = await client.PostAsync("api/clientes", content);

            // Assert
            Assert.Equal((int)HttpStatusCode.Created, (int)result.StatusCode);
        }
    }
}
