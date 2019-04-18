using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtoCommerce.Domain.Cart.Model
{
    [Flags]
    public enum CartResponseGroup
    {
        Default = 0,
        SeparateByProductOwner = 1,
    }
}
