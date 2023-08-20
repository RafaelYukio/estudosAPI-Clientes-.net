using FluentValidation;

namespace Clientes.Domain.Entities.Validations
{
    public class ClienteValidator : AbstractValidator<Cliente>
    {
        public ClienteValidator()
        {
            RuleFor(cliente => cliente.NomeCompleto)
                .NotEmpty().Length(6, 50);
            RuleFor(cliente => cliente.Telefone)
                .NotEmpty().Length(6, 50);
        }
    }
}
