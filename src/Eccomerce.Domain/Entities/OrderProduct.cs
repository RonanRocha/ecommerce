using Eccomerce.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eccomerce.Domain.Entities
{
    public class OrderProduct
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public decimal Total { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Discount { get; set; }
        public decimal UnitaryValue { get; set; }    
        public DateTime RegisterDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public EntityStatus EntityStatus { get; set; }
        public Product Product { get; set; }
        public Order Order { get; set; }
    }
}
