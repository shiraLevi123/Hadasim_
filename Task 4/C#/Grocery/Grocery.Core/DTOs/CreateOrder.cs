using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Core.DTOs
{
    public class CreateOrder
    {
        public int SupplierId { get; set; }

        public DateTime DateCreated { get; set; }

        public bool? Status { get; set; } 

        public List<CreateOrderItem> Items { get; set; }
    }
}
