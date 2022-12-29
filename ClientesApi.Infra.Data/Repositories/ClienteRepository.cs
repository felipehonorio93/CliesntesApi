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
    /// Repositório de dados para Cliente
    /// </summary>
    public class ClienteRepository : IClienteRepository
    {
        //atributo
        private readonly SqlServerContext _sqlServerContext;

        //método construtor para inicializar os atributos da classe
        //através deste construtor será feita a injeção de dependência
        public ClienteRepository(SqlServerContext sqlServerContext)
        {
            _sqlServerContext = sqlServerContext;
        }

        public void Create(Cliente entity)
        {
            _sqlServerContext.Clientes.Add(entity);
            _sqlServerContext.SaveChanges();
        }

        public void Update(Cliente entity)
        {
            _sqlServerContext.Entry(entity).State = EntityState.Modified;
            _sqlServerContext.SaveChanges();
        }

        public void Delete(Cliente entity)
        {
            _sqlServerContext.Clientes.Remove(entity);
            _sqlServerContext.SaveChanges();
        }

        public List<Cliente> GetAll()
        {
            return _sqlServerContext.Clientes.ToList();
        }

        public Cliente GetById(Guid id)
        {

            return _sqlServerContext.Clientes
                .AsNoTracking()
                .FirstOrDefault(c => c.IdCliente == id);

        }

        public Cliente GetByCpf(string cpf)
        {
            return _sqlServerContext.Clientes
                .AsNoTracking()
                .FirstOrDefault(c => c.Cpf.Equals(cpf));
        }
    }
}



