using _71MY_TraversalCore.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace _71MY_TraversalCore.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    [Route("Admin/VisitorAPI")]
    public class VisitorAPIController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public VisitorAPIController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("")]
        [Route("Index")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:57577/api/Visitor");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<VisitorAPIViewModel>>(jsonData);
                return View(values);
            }
            return View();
        }

        [Route("AddVisitor")]
        [HttpGet]
        public IActionResult AddVisitor()
        {
            return View();
        }

        [Route("AddVisitor")]
        [HttpPost]
        public async Task<IActionResult> AddVisitor(VisitorAPIViewModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:57577/api/Visitor", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "VisitorAPI", new { area = "Admin" });
            }
            return View();
        }

        [Route("DeleteVisitor/{id}")]
        public async Task<IActionResult> DeleteVisitor(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:57577/api/Visitor/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "VisitorAPI", new { area = "Admin" });
            }

            return View();
        }

        [Route("UpdateVisitor/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateVisitor(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:57577/api/Visitor/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<VisitorAPIViewModel>(jsonData);
                return View(values);
            }
            return View();
        }

        [Route("UpdateVisitor/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateVisitor(VisitorAPIViewModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync($"http://localhost:57577/api/Visitor/{model.VisitorId}", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "VisitorAPI", new { area = "Admin" });
            }
            return View();
        }
    }
}
