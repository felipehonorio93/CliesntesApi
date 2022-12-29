using ClientesApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesApi.Infra.Data.Mappings
{
    /// <summary>
    /// Classe de mapeamento para a entidade Dependente
    /// </summary>
    public class DependenteMapping : IEntityTypeConfiguration<Dependente>
    {
        public void Configure(EntityTypeBuilder<Dependente> builder)
        {
            #region Chave primária

            builder.HasKey(d => d.IdDependente);

            #endregion

            #region Campos

            builder.Property(d => d.Nome).HasMaxLength(150).IsRequired();
            builder.Property(d => d.DataNascimento).IsRequired();
            builder.Property(d => d.DataHoraCadastro).IsRequired();
            builder.Property(d => d.DataHoraUltimaAtualizacao).IsRequired();

            #endregion

            #region Chaves estrangeiras

            builder.HasOne(d => d.Cliente)
                .WithMany(c => c.Dependentes)
                .HasForeignKey(d => d.IdCliente);

            #endregion
        }
    }
}



