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
    /// Classe de mapeamento para a entidade Cliente
    /// </summary>
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            #region Chave primária

            builder.HasKey(c => c.IdCliente);

            #endregion

            #region Campos

            builder.Property(c => c.Nome).HasMaxLength(150).IsRequired();
            builder.Property(c => c.Email).HasMaxLength(100).IsRequired();
            builder.Property(c => c.Telefone).HasMaxLength(20).IsRequired();
            builder.Property(c => c.Cpf).HasMaxLength(14).IsRequired();
            builder.Property(c => c.DataHoraCadastro).IsRequired();
            builder.Property(c => c.DataHoraUltimaAtualizacao).IsRequired();

            #endregion

            #region Índices

            builder.HasIndex(c => c.Cpf).IsUnique();

            #endregion
        }
    }
}



