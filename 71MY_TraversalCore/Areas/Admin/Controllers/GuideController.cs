using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;

namespace _71MY_TraversalCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Guide")]
    public class GuideController : Controller
    {
        private readonly IGuideService _guideService;

        public GuideController(IGuideService guideService)
        {
            _guideService = guideService;
        }

        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            var values = _guideService.GetList();
            return View(values);
        }

        [Route("AddGuide")]
        [HttpGet]
        public IActionResult AddGuide()
        {
            return View();
        }

        [Route("AddGuide")]
        [HttpPost]
        public IActionResult AddGuide(Guide guide)
        {
            GuideValidator validationRules = new GuideValidator();
            ValidationResult result = validationRules.Validate(guide);

            if (result.IsValid)
            {
                guide.Status = true;
                _guideService.TAdd(guide);
                return RedirectToAction("Index", "Guide", new { area = "Admin" });
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }

        [Route("UpdateGuide/{id}")]
        [HttpGet]
        public IActionResult UpdateGuide(int id)
        {
            var value = _guideService.TGetById(id);
            return View(value);
        }

        [Route("UpdateGuide/{id}")]
        [HttpPost]
        public IActionResult UpdateGuide(Guide guide)
        {
            _guideService.TUpdate(guide);
            return RedirectToAction("Index", "Guide", new { area = "Admin" });
        }

        [Route("DeleteGuide/{id}")]
        public IActionResult DeleteGuide(int id)
        {
            var value = _guideService.TGetById(id);           
            _guideService.TDelete(value);
            return RedirectToAction("Index", "Guide", new { area = "Admin" });
        }

        [Route("ActivateGuide/{id}")]
        public IActionResult ActivateGuide(int id)
        {
            var value = _guideService.TGetById(id);
            value.Status = true;
            _guideService.TUpdate(value);
            return RedirectToAction("Index", "Guide", new { area = "Admin" });
        }

        [Route("DeactivateGuide/{id}")]
        public IActionResult DeactivateGuide(int id)
        {
            var value = _guideService.TGetById(id);
            value.Status = false;
            _guideService.TUpdate(value);
            return RedirectToAction("Index", "Guide", new { area = "Admin" });
        }
    }
}
