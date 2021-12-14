using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eccomerce.Domain.Repositories
{
    public interface IGenericRepository<T> where T : class
    {

        Task<IList<T>> GetAll();
        Task Save(T Object);
        Task<T> GetById(Guid id);
        T Update(T Object);
        Task Remove(Guid id);
    }
}
