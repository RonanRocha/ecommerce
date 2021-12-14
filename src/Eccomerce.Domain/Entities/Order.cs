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
        public OrderStatus OrderStatus { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public EntityStatus EntityStatus { get; set; }
        public PaymentMethod PaymentMethod {get;set;}
        public User User { get; set; }
        public IList<OrderProduct> OrderProducts { get; set; }
      

    }
}
