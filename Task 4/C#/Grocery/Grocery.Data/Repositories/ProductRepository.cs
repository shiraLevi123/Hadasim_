using Grocery.Core.Models;
using Grocery.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Data.Repositories
{
    public class ProductRepository: IProductRepository
    {
        private readonly DataContext _context;
        public ProductRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Product>> GetProductsBySupplierAsync(int supplierId)
        {
            return await _context.Products
                .Where(p => p.SupplierId == supplierId)
                .ToListAsync();
        }
        public async Task<Product?> GetByNameAsync(string name)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.ProductName == name);
        }

        public async Task<List<Product>> GetAllByNameAsync(string name)
        {
            return await _context.Products
                .Where(p => p.ProductName == name)
                .ToListAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}
