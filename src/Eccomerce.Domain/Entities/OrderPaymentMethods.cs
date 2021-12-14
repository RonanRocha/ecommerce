using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eccomerce.Domain.Entities
{
    public class OrderPaymentMethods
    {
        public Guid Id { get; set; }
        public decimal PaidValue { get; set; }
        public int? Installments { get; set; }
        public Guid PaymentMethodId { get; set; }
        public Guid OrderId { get; set; }
        public DateTime RegisterDate { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public Order Order { get; set; }
    }
}
