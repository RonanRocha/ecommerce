using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eccomerce.Domain.Repositories
{
    public interface IGenericRepository<TEntity, TKey> where TEntity : class
    {

        Task<IList<TEntity>> GetAll();
        Task Save(TEntity entity);
        Task<TEntity> GetById(TKey id);
        Task Update(TEntity entity);
        Task Remove(TKey id);
    }
}
