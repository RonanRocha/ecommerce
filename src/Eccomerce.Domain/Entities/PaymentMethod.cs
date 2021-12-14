using Eccomerce.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eccomerce.Domain.Entities
{
    public class PaymentMethod
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string  Description { get; set; }
        public int? PermitedInstallments { get; set; }
        public PaymentMethodType  PaymentMethodType { get; set; }
        public DateTime RegisterDate { get; set; }
        public IList<OrderPaymentMethods> OrderPaymentMethods { get; set; }
    }
}
