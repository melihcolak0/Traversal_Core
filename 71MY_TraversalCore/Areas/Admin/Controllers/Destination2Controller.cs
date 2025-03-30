using _71MY_TraversalCore.Models;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace _71MY_TraversalCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class Destination2Controller : Controller
    {
        private readonly IDestinationService _destinationService;

        public Destination2Controller(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        // Statik City Listeleme
        public IActionResult ListDestinationsStatic()
        {
            var jsonDest = JsonConvert.SerializeObject(cities);
            return Json(jsonDest);
        }
        
        public static List<CityAjax> cities = new List<CityAjax>
        {
            new CityAjax
            {
                CityId = 1,
                CityName = "Üsküp",
                CityCountry = "Makedonya"
            },

            new CityAjax
            {
                CityId = 2,
                CityName = "Roma",
                CityCountry = "İtalya"
            },

            new CityAjax
            {
                CityId = 3,
                CityName = "Londra",
                CityCountry = "İngiltere"
            }
        };

        // Dinamik Destination İşlemleri
        public IActionResult ListDestinationsDynamic()
        {
            var jsonDest = JsonConvert.SerializeObject(_destinationService.GetList());
            return Json(jsonDest);
        }
        
        [HttpPost]
        public IActionResult AddDestinationDynamic(Destination destination)
        {
            _destinationService.TAdd(destination);
            var values = JsonConvert.SerializeObject(destination);
            return Json(values);
        }

        public IActionResult GetDestinationByIdDynamic(int DestinationId)
        {
            var values = _destinationService.TGetById(DestinationId);
            var jsonValues = JsonConvert.SerializeObject(values);
            return Json(jsonValues);
        }
        
        public IActionResult UpdateDestinationDynamic(Destination destination)
        {
            destination.Image = destination.Image;
            destination.Description = destination.Description;
            destination.Status = destination.Status;
            destination.CoverImage = destination.CoverImage;
            destination.Details1 = destination.Details1;
            destination.Details2 = destination.Details2;
            destination.Image2 = destination.Image2;            
            _destinationService.TUpdate(destination);
            var values = JsonConvert.SerializeObject(destination);
            return Json(values);
        }

        public IActionResult DeleteDestinationDynamic(int id)
        {
            var value = _destinationService.TGetById(id);
            _destinationService.TDelete(value);
            return NoContent();
        }
    }
}
