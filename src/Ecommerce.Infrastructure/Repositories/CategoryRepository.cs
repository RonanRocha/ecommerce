using Eccomerce.Domain.Entities;
using Eccomerce.Domain.Repositories;
using Ecommerce.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {

        private readonly AppDataContext _ctx;

        public CategoryRepository(AppDataContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IList<Category>> GetAll()
        {
           return  await _ctx.Categories.AsNoTracking()
                .ToListAsync();
        }

        public async Task<Category> GetById(Guid id)
        {
            return await _ctx.Categories.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Category GetByName(string name)
        {
            return _ctx.Categories.FirstOrDefault(x => x.Name.ToLower() == name.ToLower());
        }

        public async Task Remove(Guid id)
        {
            var category = await _ctx.Categories.Where(x => x.Id == id).FirstOrDefaultAsync();

            _ctx.Categories.Remove(category);
        }

        public async  Task Save(Category category)
        {
            category.RegisterDate = DateTime.Now;

            await _ctx.Categories.AddAsync(category);
        }

        public Category Update(Category category)
        {
              _ctx.Entry(category).State = EntityState.Modified;

              return category;       
        }

       
    }
}
