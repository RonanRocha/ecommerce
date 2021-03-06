using Eccomerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.Builders
{
    public interface ITokenBuilder
    {
        public  Task<string> Build(User user);
    }
}
