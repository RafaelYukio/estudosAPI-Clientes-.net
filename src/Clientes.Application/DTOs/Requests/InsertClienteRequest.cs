using Clientes.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Clientes.Application.DTOs.Requests
{
    public class InsertClienteRequest
    {
        [Required(ErrorMessage = "{0} é obrigatório")]
        [StringLength(20, ErrorMessage = "{0} deve ter entre {2} e {1} caracteres", MinimumLength = 6)]
        public string NomeCompleto { get; set; }
        [Required(ErrorMessage = "{0} é obrigatório")]
        public string Telefone { get; set; }
        [Required(ErrorMessage = "{0} é obrigatório")]
        [EmailAddress(ErrorMessage = "{0} é inválido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "{0} é obrigatório")]
        public string Endereco { get; set; }

        public InsertClienteRequest(string nomeCompleto, string telefone, string email, string endereco)
        {
            NomeCompleto = nomeCompleto;
            Telefone = telefone;
            Email = email;
            Endereco = endereco;
        }

        public Cliente ConverterParaEntidade()
        {
            Detalhes detalhes = new(Endereco, Email);
            Cliente cliente = new(NomeCompleto, Telefone);
            cliente.Detalhes = detalhes;

            return cliente;
        }
    }
}
