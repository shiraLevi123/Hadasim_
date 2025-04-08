using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Core.DTOs
{
    public class CreateOrderItem
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
