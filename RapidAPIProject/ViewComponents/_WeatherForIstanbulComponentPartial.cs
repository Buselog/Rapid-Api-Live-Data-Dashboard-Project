using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace RapidAPIProject.Models
{
    public class _WeatherForIstanbulComponentPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://open-weather13.p.rapidapi.com/fivedaysforcast?latitude=41.0082&longitude=28.9784&lang=EN"),
                Headers =
    {
        { "x-rapidapi-key", "74100e61c2msh84c2befa28174e2p117c97jsn77dd52015752" },
        { "x-rapidapi-host", "open-weather13.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<WeatherViewModel>(body);
                return View(value);
            }
        }
    }
}
