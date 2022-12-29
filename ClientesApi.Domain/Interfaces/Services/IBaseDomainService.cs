using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesApi.Domain.Interfaces.Services
{
    /// <summary>
    /// Interface genérica para definir os métodos basicos da camada de serviços
    /// </summary>
    public interface IBaseDomainService<TEntity>
        where TEntity : class
    {
        void Create(TEntity entity);

        void Update(TEntity entity);

        void Delete(Guid id);

        List<TEntity> GetAll();

        TEntity GetById(Guid id);
    }
}



