using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Core.Models
{
    public class Order
    {
        public int Id { get; set; }
        public Supplier Supplier { get; set; }
        public int SupplierId { get; set; }  
        public List<OrderItem> Items { get; set; }
        public bool? Status { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
