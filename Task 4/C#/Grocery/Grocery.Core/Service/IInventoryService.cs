﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Core.Service
{
    public interface IInventoryService
    {
        Task<List<string>> HandleSaleAndCheckStockAsync(Dictionary<string, int> soldItems);

    }
}
