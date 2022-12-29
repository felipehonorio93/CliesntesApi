using System.ComponentModel.DataAnnotations;

namespace ClientesApi.Application.Requests
{
    /// <summary>
    /// Modelo de dados para a requisição POST /api/dependentes
    /// </summary>
    public class DependentesPostRequest
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public DateTime? DataNascimento { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public Guid? IdCliente { get; set; }
    }
}



