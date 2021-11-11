using Microsoft.EntityFrameworkCore;

namespace ShareSockInformation.Model
{
    public class StockContext : DbContext
    {
        public StockContext(DbContextOptions<StockContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Stock> Stocks { get; set; }
    }
}
