using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidAPIProject.Models;

namespace RapidAPIProject.ViewComponents
{
    public class _EthereumToUSDComponentPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
           
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://binance43.p.rapidapi.com/ticker/24hr?symbol=ETHUSDT"),
                Headers =
                {
        { "x-rapidapi-key", "696855c041msh18d7ed52e606137p11378djsna981e10888b4" },
        { "x-rapidapi-host", "binance43.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<CryptoViewModel2>(body);
                return View(value);
            }
        }
    }
}
