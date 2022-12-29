using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesApi.Domain.Entities
{
    /// <summary>
    /// Modelo de dados de dominio para Dependente
    /// </summary>
    public class Dependente
    {
        #region Propriedades

        public Guid? IdDependente { get; set; }
        public string? Nome { get; set; }
        public DateTime? DataNascimento { get; set; }
        public Guid? IdCliente { get; set; }
        public DateTime? DataHoraCadastro { get; set; }
        public DateTime? DataHoraUltimaAtualizacao { get; set; }

        #endregion

        #region Relacionamentos

        public Cliente? Cliente { get; set; }

        #endregion
    }
}



