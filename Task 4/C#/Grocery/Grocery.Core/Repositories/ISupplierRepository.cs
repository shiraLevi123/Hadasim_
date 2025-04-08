using Grocery.Core.DTOs;
using Grocery.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Core.Repositories
{
    public interface ISupplierRepository
    {
        Task<Supplier?> GetByNameAsync(string name);
        Task AddSupplierAsync(Supplier supplier);
        Task<BestSupplierDTO?> GetCheapestSupplierForProductAsync(string productName);


    }
}
