using FluentValidation;

namespace Clientes.Domain.Entities.Validations
{
    public class DetalhesValidator : AbstractValidator<Detalhes>
    {
        public DetalhesValidator()
        {
            RuleFor(detalhes => detalhes.Email)
                .NotEmpty().EmailAddress();
            RuleFor(detalhes => detalhes.Endereco)
                .NotEmpty().Length(6, 50);
        }
    }
}
