using System.ComponentModel.DataAnnotations;

namespace ClientesApi.Application.Requests
{
    /// <summary>
    /// Modelo de dados para a requisição PUT /api/dependentes
    /// </summary>
    public class DependentesPutRequest
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        public Guid? IdDependente { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public DateTime? DataNascimento { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public Guid? IdCliente { get; set; }
    }
}



