﻿using Grocery.Core.DTOs;
using Grocery.Core.Models;
using Grocery.Core.Repositories;
using Grocery.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await _orderRepository.GetAllOrdersAsync();
        }
        public async Task<List<Order>> GetOrdersBySupplierIdAsync(int supplierId)
        {
            return await _orderRepository.GetOrdersBySupplierIdAsync(supplierId);
        }
        public async Task<Order> ApproveOrderAsync(int orderId)
        {
            var order = await _orderRepository.GetOrderByIdAsync(orderId);

            order.Status = true;

            await _orderRepository.UpdateOrderAsync(order);

            return order;
        }
        public async Task<Order> GetOrderByIdAsync(int orderId)
        {
            return await _orderRepository.GetOrderByIdAsync(orderId);
        }
        public async Task<Order> CreateOrderAsync(CreateOrder dto)
        {
            var order = new Order
            {
                SupplierId = dto.SupplierId,
                DateCreated = dto.DateCreated,
                Status = dto.Status,
                Items = dto.Items.Select(
                     i => new OrderItem
                     {
                         ProductId = i.ProductId,
                         Quantity = i.Quantity,
                     }).ToList()
            };
            await _orderRepository.AddAsync(order);
            return order;
        }
        //public async Task<Order> CreateOrderAsync(CreateOrderDto dto)
        //{
        //    var supplier = await _supplierRepository.GetByNameAsync(dto.SupplierName);
        //    if (supplier == null)
        //        throw new Exception("אין ספק כזה בDB");

        //    var order = new Order
        //    {
        //        SupplierId = supplier.Id,
        //        CreatedAt = dto.CreatedAt,
        //        Status = OrderStatus.Pending,
        //        Items = new List<OrderItem>()
        //    };

        //    foreach (var item in dto.Items)
        //    {
        //        var product = await _productRepository.GetByNameAndSupplierIdAsync(item.ProductName, supplier.Id);
        //        if (product == null)
        //            throw new Exception($"Product '{item.ProductName}' not found for supplier ");
        //        if (item.Quantity < product.MinQuantity)
        //            throw new Exception($"לא ניתן להזמין את '{product.Name}' בכמות קטנה מ-{product.MinQuantity}");
        //        order.Items.Add(new OrderItem
        //        {
        //            ProductId = product.Id,
        //            Quantity = item.Quantity
        //        });
        //    }

        //    await _orderRepository.AddOrderAsync(order);
        //    return order;

        //}
        public async Task<Order> MarkOrderAsCompletedAsync(int orderId)
        {
            var order = await _orderRepository.GetOrderByIdAsync(orderId);
            if (order == null)
                throw new Exception("Order not found");

            order.Status = true;
            await _orderRepository.UpdateOrderAsync(order);

            return order;
        }
    }
}
