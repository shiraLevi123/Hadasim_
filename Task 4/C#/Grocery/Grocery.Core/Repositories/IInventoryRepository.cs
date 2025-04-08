using Grocery.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Core.Repositories
{
    public interface IInventoryRepository
    {
        Task UpdateAsync(Inventory item);
        Task<Inventory?> GetByNameAsync(string productName);

    }
}
