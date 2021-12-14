using Eccomerce.Domain.Entities;
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
    public class ProductRepository : GenericRepository<Product, Guid>,   IProductRepository
    {

        public ProductRepository(AppDataContext context) : base(context)
        {
        }



    }
}
