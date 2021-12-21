using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.Dto
{
    public class PaymentMethodDto
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public string Description { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public OrderDto Order { get; set; }
    }
}
