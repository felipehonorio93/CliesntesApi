using System.ComponentModel.DataAnnotations;

namespace ClientesApi.Application.Requests
{
    public class ClientesPostRequest
    {
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
