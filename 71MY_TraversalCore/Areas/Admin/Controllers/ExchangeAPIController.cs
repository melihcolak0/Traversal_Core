using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using _71MY_TraversalCore.Areas.Admin.Models;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace _71MY_TraversalCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class ExchangeAPIController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<ExchangeAPIViewModel2> model = new List<ExchangeAPIViewModel2>();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/metadata/exchange-rates?locale=en-gb&currency=TRY"),
                Headers =
    {
        { "x-rapidapi-key", "1f7673f899msh84df4be209ff6f4p13b935jsn145ec77e73ef" },
        { "x-rapidapi-host", "booking-com.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<ExchangeAPIViewModel2>(body);

                Console.WriteLine(body);
                return View(values.exchange_rates);
            }
        }
    }
}
