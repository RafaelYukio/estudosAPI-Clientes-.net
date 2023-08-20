using Clientes.Domain.Entities.Base;
using Clientes.Domain.Entities.Validations;

namespace Clientes.Domain.Entities
{
    public class Cliente : BaseEntity
    {
        public string NomeCompleto { get; set; }
        public string Telefone { get; set; }
        public Detalhes Detalhes { get; set; }

        public Cliente(string nomeCompleto, string telefone)
        {
            NomeCompleto = nomeCompleto;
            Telefone = telefone;

            Validate();
        }

        public override void Validate()
        {
            var validator = new ClienteValidator();
            if (!validator.Validate(this).IsValid)
            {
                throw new InvalidOperationException($"Não é possível criar {GetType().Name}.");
            }
        }
    }
}