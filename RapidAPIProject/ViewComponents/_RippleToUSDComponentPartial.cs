using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidAPIProject.Models;

namespace RapidAPIProject.ViewComponents
{
    public class _RippleToUSDComponentPartial: ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://crypto-market-prices.p.rapidapi.com/currencies/convert?from=XRP&to=USD&amount=1"),
                Headers =
    {
        { "x-rapidapi-key", "74100e61c2msh84c2befa28174e2p117c97jsn77dd52015752" },
        { "x-rapidapi-host", "crypto-market-prices.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<CryptoViewModel>(body);
                return View(value);
            }
        }
    }
}
