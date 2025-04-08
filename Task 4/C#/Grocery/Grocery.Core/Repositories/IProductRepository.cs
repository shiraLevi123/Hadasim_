using Grocery.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Core.Repositories
{
    public interface IProductRepository

    {
        Task<List<Product>> GetProductsBySupplierAsync(int supplierId);
        Task<Product?> GetByNameAsync(string name);
        Task<List<Product>> GetAllByNameAsync(string name);
        Task UpdateAsync(Product product);
    }
}
