﻿using Grocery.Core.DTOs;
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
    public class SupplierRepository: ISupplierRepository
    {
        private readonly DataContext _context;
        public SupplierRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Supplier?> GetByNameAsync(string name)
        {
            return await _context.Suppliers
                .FirstOrDefaultAsync(s => s.CompanyName == name);
        }
        public async Task AddSupplierAsync(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            await _context.SaveChangesAsync();
        }
  public async Task<BestSupplierDTO?> GetCheapestSupplierForProductAsync(string productName)
        {
            return await _context.Products
                .Where(p => p.ProductName == productName)
                .OrderBy(p => p.PricePerUnit)
                .Select(p => new BestSupplierDTO
                {
                    SupplierId = p.SupplierId,
                    ProductId = p.Id,
                    MinQuantity = p.MinQuantity
                })
                .FirstOrDefaultAsync();
        }

    }
}
