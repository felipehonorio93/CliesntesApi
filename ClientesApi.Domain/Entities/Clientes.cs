using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesApi.Domain.Entities
{
    /// <summary>
    /// Modelo de dados de dominio para Cliente
    /// </summary>
    public class Cliente
    {
        #region Propriedades

        public Guid? IdCliente { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Cpf { get; set; }
        public string? Telefone { get; set; }
        public DateTime? DataHoraCadastro { get; set; }
        public DateTime? DataHoraUltimaAtualizacao { get; set; }

        #endregion

        #region Relacionamentos

        public List<Dependente>? Dependentes { get; set; }

        #endregion
    }
}



