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
    public class StockCreationModel : PageModel
    {
        private readonly StockSevice stockSevice;
        
        public List<Stock> Shares { get; set; }

        [BindProperty]
        public Stock[] Shared { get; set; }

        public StockCreationModel(StockSevice stockSevice)
        {
            this.stockSevice = stockSevice;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var shares = await stockSevice.GetShares();
            Shares = shares;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await stockSevice.AddTopTenShares(Shared);
            return RedirectToPage("./StockDisplay");
        }
    }
}
