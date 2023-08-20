using Clientes.Domain.Entities.Base;
using Clientes.Domain.Entities.Validations;

namespace Clientes.Domain.Entities
{
    public class Detalhes : BaseEntity
    {
        public string Endereco { get; set; }
        public string Email { get; set; }
        public Cliente Cliente { get; set; }

        public Detalhes(string endereco, string email)
        {
            Endereco = endereco;
            Email = email;

            Validate();
        }

        public override void Validate()
        {
            var validator = new DetalhesValidator();
            if(!validator.Validate(this).IsValid)
            {
                throw new InvalidOperationException($"Não é possível criar {GetType().Name}.");
            }
        }
    }
}
