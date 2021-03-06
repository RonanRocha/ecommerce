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
    public class CategoryRepository : GenericRepository<Category, Guid>, ICategoryRepository
    {

        public CategoryRepository(AppDataContext context) : base(context)
        {
        }

        public Category GetByName(string name)
        {
            return _ctx.Categories.Where(x => x.Name.ToLower() == name.ToLower()).FirstOrDefault();
        }
    }
}
