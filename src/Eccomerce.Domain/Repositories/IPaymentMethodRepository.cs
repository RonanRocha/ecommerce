using Eccomerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eccomerce.Domain.Repositories
{
    public interface IPaymentMethodRepository : IGenericRepository<PaymentMethod, Guid>
    {
    }
}
