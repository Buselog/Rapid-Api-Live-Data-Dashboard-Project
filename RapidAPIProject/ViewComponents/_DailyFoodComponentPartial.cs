using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidAPIProject.Models;

namespace RapidAPIProject.ViewComponents
{
    public class _DailyFoodComponentPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var random = new Random();
            int from = random.Next(0, 100); 
            string apiUrl = $"https://tasty.p.rapidapi.com/recipes/list?from={from}&size=1";

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(apiUrl),
                Headers =
            {
               { "x-rapidapi-key", "74100e61c2msh84c2befa28174e2p117c97jsn77dd52015752" },
               { "x-rapidapi-host", "tasty.p.rapidapi.com" },
            },
            };

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<DailyFoodViewModel>(body);
                return View(value.results.FirstOrDefault());
            }
        }
    }
}
