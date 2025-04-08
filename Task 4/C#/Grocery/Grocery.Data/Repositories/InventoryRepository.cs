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
    public class InventoryRepository: IInventoryRepository
    {
        private readonly DataContext _context;
        public InventoryRepository(DataContext context)
        {
            _context = context;
        }
        public async Task UpdateAsync(Inventory item)
        {

            _context.Inventory.Update(item);
            await _context.SaveChangesAsync();
        }
        public async Task<Inventory?> GetByNameAsync(string productName)
        {
            return await _context.Inventory
                .FirstOrDefaultAsync(p => p.ProductName == productName);
        }

    }
}
