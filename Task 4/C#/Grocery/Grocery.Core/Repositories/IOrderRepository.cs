using Grocery.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Core.Repositories
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllOrdersAsync();
        Task<List<Order>> GetOrdersBySupplierIdAsync(int supplierId);
        Task<Order> GetOrderByIdAsync(int orderId);
        Task UpdateOrderAsync(Order order);
        Task AddAsync(Order order);

    }
}
