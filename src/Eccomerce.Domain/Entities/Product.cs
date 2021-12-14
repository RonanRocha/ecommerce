using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eccomerce.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime RegisterDate { get; set; }
        public string CategoryId { get; set; }
        public Category Category { get; set; }
        public IList<OrderProducts> OrderProducts { get; set; }

    }
}
