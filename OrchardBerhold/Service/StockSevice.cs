using Newtonsoft.Json;
using OrchardBerhold.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace OrchardBerhold.Service
{
    public class StockSevice
    {
        private readonly HttpClient client;

        public StockSevice(HttpClient client)
        {
            this.client = client;
        }

        public async Task<List<Stock>> GetShares()
        {
            var shares = await this.client.GetStringAsync("api/stock/shares");
            List<Stock> sharesStock = JsonConvert.DeserializeObject<List<Stock>>(shares);
            return sharesStock;
        }

        public async Task<List<Stock>> GetShared()
        {
            var shares = await this.client.GetStringAsync("api/stock/shared");
            List<Stock> sharesStock = JsonConvert.DeserializeObject<List<Stock>>(shares);
            return sharesStock;
        }

        public async Task AddTopTenShares(Stock[] stocks)
        {
            HttpContent httpContent = new StringContent(
                    JsonConvert.SerializeObject(stocks),
                    Encoding.UTF8, Application.Json
                );
            var response = await this.client.PostAsync("api/stock/shares", httpContent);
            response.EnsureSuccessStatusCode();
        }
    }
}
