using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Core.DTOs
{
    public class ProductDTO
    {
        public string ProductName { get; set; }
        public decimal PricePerUnit { get; set; }
        public int MinQuantity { get; set; }
    }
}
