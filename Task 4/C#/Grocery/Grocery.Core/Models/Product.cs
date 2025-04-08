using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Core.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal PricePerUnit { get; set; }
        public int MinQuantity { get; set; }
       // public Supplier Supplier { get; set; }
        public int SupplierId { get; set; }
       // public int CurrentStock { get; set; }
    }
}