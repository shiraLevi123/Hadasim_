using Grocery.Core.DTOs;
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
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;

        public SupplierService(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }
           public async Task<Supplier?> LoginAsync(Login dto)
        {
            var supplier = await _supplierRepository.GetByNameAsync(dto.CompanyName);

            if (supplier == null || supplier.Password != dto.Password)
                return null;

            return supplier;
        }
        public async Task<Supplier> RegisterSupplierAsync(Register dto)
        {
            var supplier = new Supplier
            {
                CompanyName = dto.CompanyName,
                Phone = dto.Phone,
                AgentName = dto.AgentName,
                Password = dto.Password,
                Products = dto.Products.Select(p => new Product
                {
                    ProductName = p.ProductName,
                    PricePerUnit = p.PricePerUnit,
                    MinQuantity = p.MinQuantity
                }).ToList()
            };

            await _supplierRepository.AddSupplierAsync(supplier);
            return supplier;
        }

    }
}