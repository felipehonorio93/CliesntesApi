using System.ComponentModel.DataAnnotations;

namespace ClientesApi.Application.Requests
{
    /// <summary>
    /// Modelo de dados para a requisição POST /api/auth
    /// </summary>
    public class AuthPostRequest
    {
        [EmailAddress(ErrorMessage = "Por favor, informe um email válido.")]
        [Required(ErrorMessage = "Por favor, informe o email do usuário.")]
        public string? Email { get; set; }

        [MinLength(8, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(20, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe a senha do usuário.")]
        public string? Senha { get; set; }
    }
}

    

