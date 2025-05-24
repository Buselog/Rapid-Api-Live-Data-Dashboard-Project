using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidAPIProject.Models;

namespace RapidAPIProject.ViewComponents
{
    public class _NewsComponentPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://global-economy-news.p.rapidapi.com/?country=us&limit=5"),
                Headers =
    {
        { "x-rapidapi-key", "74100e61c2msh84c2befa28174e2p117c97jsn77dd52015752" },
        { "x-rapidapi-host", "global-economy-news.p.rapidapi.com" },
    },
            };

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<NewsViewModel>(body);
                
                var limitedData = value?.response?.data?.Take(5).ToArray();

                return View(limitedData);
            }

        }
    }
}
