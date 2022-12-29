using ClientesApi.Domain.Entities;
using ClientesApi.Domain.Interfaces.Repositories;
using ClientesApi.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesApi.Infra.Data.Repositories
{
    /// <summary>
    /// Repositório de dados para Dependente
    /// </summary>
    public class DependenteRepository : IDependenteRepository
    {
        //atributo
        private readonly SqlServerContext _sqlServerContext;

        //construtor para injeção de dependência (inicialização do atributo)
        public DependenteRepository(SqlServerContext sqlServerContext)
        {
            _sqlServerContext = sqlServerContext;
        }

        public void Create(Dependente entity)
        {
            _sqlServerContext.Dependentes.Add(entity);
            _sqlServerContext.SaveChanges();
        }

        public void Update(Dependente entity)
        {
            _sqlServerContext.Entry(entity).State = EntityState.Modified;
            _sqlServerContext.SaveChanges();
        }

        public void Delete(Dependente entity)
        {
            _sqlServerContext.Dependentes.Remove(entity);
            _sqlServerContext.SaveChanges();
        }

        public List<Dependente> GetAll()
        {
            return _sqlServerContext.Dependentes.ToList();
        }

        public Dependente GetById(Guid id)
        {
            return _sqlServerContext.Dependentes
                .AsNoTracking()
                .FirstOrDefault(d => d.IdDependente == id);
        }
    }
}



