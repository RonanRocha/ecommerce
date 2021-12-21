using Eccomerce.Domain.Entities;
using Eccomerce.Domain.Repositories;
using Ecommerce.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.Repositories
{
    public class PaymentMethodRepository : GenericRepository<PaymentMethod, Guid>, IPaymentMethodRepository
    {
        public PaymentMethodRepository(AppDataContext context) : base(context)
        {
        }
    }
    
}
