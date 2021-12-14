using Eccomerce.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eccomerce.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public string OrderCode { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Total { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Discount { get; set; }
        public decimal Extra { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public User User { get; set; }
        public IList<OrderProducts> OrderProducts { get; set; }
        public IList<OrderPaymentMethods> OrderPaymentMethods { get; set; }


    }
}
