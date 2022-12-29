namespace ClientesApi.Application.Responses
{
    /// <summary>
    /// Modelo de dados para a consulta de clientes GET /api/Clientes
    /// </summary>
    public class ClientesGetResponse
    {
        public Guid? IdCliente { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Cpf { get; set; }
        public string? Telefone { get; set; }
        public List<DependentesGetResponse>? Dependentes { get; set; }
    }
}



