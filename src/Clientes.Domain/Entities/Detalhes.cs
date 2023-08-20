using Clientes.Domain.Entities.Base;

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
        }
    }
}
