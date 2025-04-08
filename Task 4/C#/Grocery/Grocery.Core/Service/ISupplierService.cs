using Grocery.Core.DTOs;
using Grocery.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Core.Service
{
    public interface ISupplierService
    {
        Task<Supplier?> LoginAsync(Login dto);
        Task<Supplier> RegisterSupplierAsync(Register dto);
    }
}
