using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using _71MY_TraversalCore.Areas.Admin.Models;
using Newtonsoft.Json;

namespace _71MY_TraversalCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class HotelSearchAPIController : Controller
    {
        public async Task<IActionResult> Index()
        {
            
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/hotels/search?page_number=0&order_by=popularity&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1&adults_number=2&units=metric&dest_id=-1456928&room_number=1&checkin_date=2025-06-16&include_adjacency=true&filter_by_currency=EUR&locale=en-gb&children_ages=5%2C0&children_number=2&dest_type=city&checkout_date=2025-06-17"),
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
                var values = JsonConvert.DeserializeObject<HotelSearchAPIViewModel>(body);
                return View(values.result);
            }
        }

        [HttpGet]
        public IActionResult GetCityDestId()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetCityDestId(string p)
        {            
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?name={p}&locale=en-gb"),
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

                return View();
            }
        }
    }    
}
