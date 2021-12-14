using Eccomerce.Domain.Repositories;
using Ecommerce.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.Repositories
{
    public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : class
    {

        protected AppDataContext _ctx;

        public GenericRepository(AppDataContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IList<TEntity>> GetAll()
        {
            return await _ctx.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetById(TKey id)
        {
            return await _ctx.Set<TEntity>().FindAsync(id);
        }

        public async Task Remove(TKey id)
        {
            var obj = await _ctx.Set<TEntity>().FindAsync(id);
            _ctx.Set<TEntity>().Remove(obj);
        }

        public async Task Save(TEntity Object)
        {
             await _ctx.Set<TEntity>().AddAsync(Object);
        }

        public async  Task Update(TEntity Object)
        {
           _ctx.Set<TEntity>().Update(Object);
        }
    }
}
