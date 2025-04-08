using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Core.DTOs
{
    public class BestSupplierDTO
    {
        public int SupplierId { get; set; }
        public int ProductId { get; set; }
        public int MinQuantity { get; set; }
    }
}
