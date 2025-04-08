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
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly DataContext _context;
        public OrderItemRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Product>> GetProductsBySupplierAsync(int supplierId)
        {
            return await _context.Products
                .Where(p => p.SupplierId == supplierId)
                .ToListAsync();
        }
    }
}
