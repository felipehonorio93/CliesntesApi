using System.ComponentModel.DataAnnotations;

namespace ClientesApi.Application.Requests
{
    /// <summary>
    /// Modelo de dados para a requisição PUT /api/clientes
    /// </summary>
    public class ClientesPutRequest
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        public Guid? IdCliente { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string? Cpf { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string? Telefone { get; set; }
    }
}



