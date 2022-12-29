namespace ClientesApi.Application.Responses
{
    /// <summary>
    /// Modelo de dados para a resposta de autenticação da API
    /// </summary>
    public class AuthGetResponse
    {
        /// <summary>
        /// Nome do usuário autenticao
        /// </summary>
        public string? NomeUsuario { get; set; }

        /// <summary>
        /// Email do usuário autenticado
        /// </summary>
        public string? EmailUsuario { get; set; }

        /// <summary>
        /// Token do usuário autenticado
        /// </summary>
        public string? AccessToken { get; set; }

        /// <summary>
        /// Data e Hora de acesso
        /// </summary>
        public DateTime DataHoraAcesso { get; set; }
    }
}



