using System.Net.Http.Headers;

namespace Clientes.Domain.Entities.Base
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        public abstract void Validate();
    }
}
