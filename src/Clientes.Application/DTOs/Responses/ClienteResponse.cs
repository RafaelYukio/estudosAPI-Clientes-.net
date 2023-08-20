namespace Clientes.Application.DTOs.Responses
{
    public record ClienteResponse(
        int Id,
        string NomeCompleto,
        string Telefone,
        string Email,
        string Endereco
        );
}
