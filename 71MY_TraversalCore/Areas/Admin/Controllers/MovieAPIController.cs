using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;
using _71MY_TraversalCore.Areas.Admin.Models;
using Newtonsoft.Json;

namespace _71MY_TraversalCore.Areas.Admin.Controllers
{
    public class MovieAPIController : Controller
    {
        [Area("Admin")]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            List<MovieAPIViewModel> model = new List<MovieAPIViewModel>();

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
                Headers =
                        {
                            { "x-rapidapi-key", "1f7673f899msh84df4be209ff6f4p13b935jsn145ec77e73ef" },
                            { "x-rapidapi-host", "imdb-top-100-movies.p.rapidapi.com" },
                        },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                model = JsonConvert.DeserializeObject<List<MovieAPIViewModel>>(body);
                Console.WriteLine(body);
                return View(model);
            }
            
        }
    }
}
