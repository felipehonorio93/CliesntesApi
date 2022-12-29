using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesApi.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Interface genérica para definir os métodos basicos do repositório
    /// </summary>
    public interface IBaseRepository<TEntity>
        where TEntity : class
    {
        void Create(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        List<TEntity> GetAll();

        TEntity GetById(Guid id);
    }
}



            