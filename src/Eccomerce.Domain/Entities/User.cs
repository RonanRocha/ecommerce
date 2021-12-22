using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Eccomerce.Domain.Entities
{
    public class User : IdentityUser<Guid>
    {

        public ICollection<Order> Orders { get; set; }
        public IList<Address> Addresses { get; set; }

        public virtual ICollection<IdentityUserClaim<Guid>> Claims { get; set; }
        public virtual ICollection<IdentityUserLogin<Guid>> Logins { get; set; }
        public virtual ICollection<IdentityUserToken<Guid>> Tokens { get; set; }
        public virtual ICollection<IdentityUserRole<Guid>> UserRoles { get; set; }
    }
}
