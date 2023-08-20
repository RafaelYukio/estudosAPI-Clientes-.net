using Clientes.Domain.Entities.Base;

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
        }
    }
}