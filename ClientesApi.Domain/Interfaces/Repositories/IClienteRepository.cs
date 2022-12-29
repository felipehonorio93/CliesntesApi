using ClientesApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesApi.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Interface de repositório para cliente
    /// </summary>
    public interface IClienteRepository : IBaseRepository<Cliente>
    {
        Cliente GetByCpf(string cpf);
    }
}



