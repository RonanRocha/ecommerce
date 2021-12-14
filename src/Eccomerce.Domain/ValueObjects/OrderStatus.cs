using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eccomerce.Domain.ValueObjects
{
    public enum OrderStatus
    {
        New = 1,
        Paid = 2,
        Preparing =3,
        Deliver = 4,
        Finished = 5,
        Canceled  = 6  
    }
}
