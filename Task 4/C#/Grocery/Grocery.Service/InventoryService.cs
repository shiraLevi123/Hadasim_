using Grocery.Core.DTOs;
using Grocery.Core.Models;
using Grocery.Core.Repositories;
using Grocery.Core.Service;
using Grocery.Data.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Service
{
    public class InventoryService : IInventoryService
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IInventoryRepository _inventoryRepository;

        public InventoryService(ISupplierRepository productRepository, IOrderRepository orderRepository, IInventoryRepository inventoryRepository)
        {
            _supplierRepository = productRepository;
            _orderRepository = orderRepository;
            _inventoryRepository = inventoryRepository;
        }

        public async Task<List<string>> HandleSaleAndCheckStockAsync(Dictionary<string, int> soldItems)
        {
            var missingProducts = new List<string>();

            foreach (var item in soldItems)
            {
                var productName = item.Key;
                var quantitySold = item.Value;

                var inventoryItem = await _inventoryRepository.GetByNameAsync(productName);
                if (inventoryItem == null)
                {
                    missingProducts.Add($"{productName} - המוצר לא נמצא במלאי");
                    continue;
                }

                inventoryItem.NowQuantity -= quantitySold;

                if (inventoryItem.NowQuantity < inventoryItem.MinQuantity)
                {
                    var bestSupplier = await _supplierRepository.GetCheapestSupplierForProductAsync(productName);

                    if (bestSupplier != null)
                    {
                        var order = new Order
                        {
                            SupplierId = bestSupplier.SupplierId,
                            DateCreated = DateTime.Now,
                            Status = false,
                            Items = new List<OrderItem>
                     {
                         new OrderItem
                         {
                             ProductId = bestSupplier.ProductId,
                             Quantity = bestSupplier.MinQuantity
                         }
                     }
                        };

                        await _orderRepository.AddAsync(order);
                    }
                    else
                    {
                        missingProducts.Add($"{productName} - אף ספק אינו משווק את המוצר");
                    }
                }

                await _inventoryRepository.UpdateAsync(inventoryItem);
            }

            return missingProducts;
        }
    }
}