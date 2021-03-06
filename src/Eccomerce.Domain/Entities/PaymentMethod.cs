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
        public string Description { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public EntityStatus EntityStatus { get; set; }
        public Order Order { get; set; }
    }
}
