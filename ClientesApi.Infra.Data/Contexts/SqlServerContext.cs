using ClientesApi.Domain.Entities;
using ClientesApi.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesApi.Infra.Data.Contexts
{
    /// <summary>
    /// Classe de contexto do EntityFramework
    /// </summary>
    public class SqlServerContext : DbContext
    {
        //método para mapear a connectionstring do banco de dados
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=SQL5103.site4now.net;Initial Catalog=db_a90189_bdapiclientes;User Id=db_a90189_bdapiclientes_admin;Password=Fe100293");
        }

        //método para incluir as classes mapeadas (ORM):
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteMapping());
            modelBuilder.ApplyConfiguration(new DependenteMapping());
        }

        //declarar uma propriedade DbSet (CRUD) para cada classe de entidade
        public DbSet<Cliente>? Clientes { get; set; }
        public DbSet<Dependente>? Dependentes { get; set; }
    }
}



