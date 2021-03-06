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



        public async Task Save(TEntity entity)
        {
             await _ctx.Set<TEntity>().AddAsync(entity);
        }

        public  Task Update(TEntity entity)
        {
           _ctx.Set<TEntity>().Update(entity);
            return Task.CompletedTask;
        }
    }
}
