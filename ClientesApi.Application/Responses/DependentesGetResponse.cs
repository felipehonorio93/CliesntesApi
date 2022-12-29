namespace ClientesApi.Application.Responses
{
    /// <summary>
    /// Modelo de dados para a consulta de dependentes GET /api/Dependentes
    /// </summary>
    public class DependentesGetResponse
    {
        public Guid? IdDependente { get; set; }
        public string? Nome { get; set; }
        public string? DataNascimento { get; set; }
    }
}



