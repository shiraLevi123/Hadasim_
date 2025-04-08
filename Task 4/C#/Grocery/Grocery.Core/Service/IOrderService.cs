using Grocery.Core.DTOs;
using Grocery.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Core.Service
{
    public interface IOrderService
    {
        Task<List<Order>> GetAllOrdersAsync();
        //Task<Order> MarkOrderAsCompletedAsync(int orderId);
        Task<List<Order>> GetOrdersBySupplierIdAsync(int supplierId);
        Task<Order> GetOrderByIdAsync(int orderId);
        Task<Order> ApproveOrderAsync(int orderId);
        Task<Order> CreateOrderAsync(CreateOrder dto);
        Task<Order> MarkOrderAsCompletedAsync(int orderId);




    }
}
