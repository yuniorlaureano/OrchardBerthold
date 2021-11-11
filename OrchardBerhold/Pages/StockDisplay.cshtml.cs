using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OrchardBerhold.Model;
using OrchardBerhold.Service;

namespace OrchardBerhold.Pages
{
    public class StockDisplayModel : PageModel
    {
        private readonly StockSevice stockSevice;
        public List<Stock> Shares { get; set; }

        public StockDisplayModel(StockSevice stockSevice)
        {
            this.stockSevice = stockSevice;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var shared = await stockSevice.GetShared();
            Shares = shared;
            return Page();
        }
    }
}
