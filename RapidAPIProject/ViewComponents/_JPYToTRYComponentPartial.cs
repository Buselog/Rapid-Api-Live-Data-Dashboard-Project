using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidAPIProject.Models;

namespace RapidAPIProject.ViewComponents
{
    public class _JPYToTRYComponentPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://real-time-finance-data.p.rapidapi.com/currency-exchange-rate?from_symbol=JPY&to_symbol=TRY&language=en"),
                Headers =
    {
        {"x-rapidapi-key", "696855c041msh18d7ed52e606137p11378djsna981e10888b4"},
        { "x-rapidapi-host", "real-time-finance-data.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<JPYToTRYViewModel>(body);
                return View(value);
            }
           
            }
        }
    }
