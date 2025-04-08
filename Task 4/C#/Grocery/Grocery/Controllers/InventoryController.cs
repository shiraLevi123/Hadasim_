using Grocery.Core.DTOs;
using Grocery.Core.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Grocery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;

        public InventoryController(IInventoryService restockService)
        {
            _inventoryService = restockService;
        }

        [HttpPost("process")]
        public async Task<IActionResult> HandleSaleAndCheckStockAsync([FromBody] List<SaleItemDto> saleItems)
        {
            var soldItemsDict = saleItems.ToDictionary(item => item.ProductName, item => item.Quantity);
            var missingProducts = await _inventoryService.HandleSaleAndCheckStockAsync(soldItemsDict);

            return Ok(missingProducts);
        }

    }
}