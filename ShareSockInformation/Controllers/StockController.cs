using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShareSockInformation.Model;
using System;
using System.Threading.Tasks;

namespace ShareSockInformation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockController : ControllerBase
    {
        private static readonly Stock[] stock = new Stock[]
        {
            new Stock { Name = "Product 1", Price = 12, RegistrationDate = DateTime.Now },
            new Stock { Name = "Product 2", Price = 11, RegistrationDate = DateTime.Now },
            new Stock { Name = "Product 3", Price = 13, RegistrationDate = DateTime.Now },
            new Stock { Name = "Product 4", Price = 15, RegistrationDate = DateTime.Now },
            new Stock { Name = "Product 5", Price = 16, RegistrationDate = DateTime.Now },
            new Stock { Name = "Product 6", Price = 17, RegistrationDate = DateTime.Now },
            new Stock { Name = "Product 7", Price = 18, RegistrationDate = DateTime.Now },
            new Stock { Name = "Product 8", Price = 122, RegistrationDate = DateTime.Now },
            new Stock { Name = "Product 9", Price = 152, RegistrationDate = DateTime.Now },
            new Stock { Name = "Product 10", Price = 172, RegistrationDate = DateTime.Now },
        };

        private readonly StockContext stockContext;

        public StockController(StockContext stockContext)
        {
            this.stockContext = stockContext;
        }

        [HttpGet("shares")]
        public IActionResult SharesInformation()
        {
            return Ok(stock);
        }

        [HttpGet("shared")]
        public async Task<IActionResult> SharesedInformation()
        {
            var sharedStock = await stockContext.Stocks.ToListAsync();
            return Ok(sharedStock);
        }

        [HttpPost("shares")]
        public async Task<IActionResult> SharesedInformation(Stock[] stocks)
        {
            var availableStock = await stockContext.Stocks.AnyAsync();
            if (availableStock)
            {
                stockContext.Database.ExecuteSqlRaw("DELETE FROM Stocks");
                await stockContext.SaveChangesAsync();
            }

            stockContext.Stocks.AddRange(stocks);
            await stockContext.SaveChangesAsync();
            return Ok(stock);
        }
    }
}
