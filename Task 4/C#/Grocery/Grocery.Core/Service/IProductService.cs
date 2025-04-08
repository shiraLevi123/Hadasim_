using Grocery.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Core.Service
{
    public interface IProductService
    {
        Task<List<Product>> GetProductsBySupplierAsync(int supplierId);

    }
}
