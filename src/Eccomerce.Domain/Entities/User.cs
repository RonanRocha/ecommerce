using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Eccomerce.Domain.Entities
{
    public class User : IdentityUser<Guid>
    {

        public ICollection<Order> Orders { get; set; }
        public IList<Address> Addresses { get; set; }
    }
}
