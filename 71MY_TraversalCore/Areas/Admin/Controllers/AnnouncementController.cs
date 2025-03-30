using _71MY_TraversalCore.Areas.Admin.Models;
using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.DTOs.AnnouncementDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace _71MY_TraversalCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Announcement")]
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementService _announcementService;
        private readonly IMapper _mapper;

        public AnnouncementController(IAnnouncementService announcementService, IMapper mapper)
        {
            _announcementService = announcementService;
            _mapper = mapper;
        }

        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            var values = _mapper.Map<List<AnnouncementListDTO>>(_announcementService.GetList());
            return View(values);
        }

        [Route("AddAnnouncement")]
        [HttpGet]
        public IActionResult AddAnnouncement()
        {
            return View();
        }

        [Route("AddAnnouncement")]
        [HttpPost]
        public IActionResult AddAnnouncement(AddAnnouncementDTO model)
        {
            if(ModelState.IsValid)
            {
                _announcementService.TAdd(new Announcement
                {
                    Content = model.Content,
                    Title = model.Title,
                    Date = DateTime.Now
                });
                return RedirectToAction("Index", "Announcement", new {area = "Admin"});
            }
            return View(model);
        }

        [Route("DeleteAnnouncement/{id}")]
        public IActionResult DeleteAnnouncement(int id)
        {
            var value = _announcementService.TGetById(id);
            _announcementService.TDelete(value);
            return RedirectToAction("Index", "Announcement", new { area = "Admin" });
        }

        [Route("UpdateAnnouncement/{id}")]
        [HttpGet]
        public IActionResult UpdateAnnouncement(int id)
        {
            var value = _mapper.Map<UpdateAnnouncementDTO>(_announcementService.TGetById(id));
            return View(value);
        }

        [Route("UpdateAnnouncement/{id}")]
        [HttpPost]
        public IActionResult UpdateAnnouncement(UpdateAnnouncementDTO model)
        {
            if(ModelState.IsValid)
            {
                _announcementService.TUpdate(new Announcement
                {
                    AnnouncementId = model.AnnouncementId,
                    Title = model.Title,
                    Content = model.Content,
                    Date = DateTime.Now
                });
                return RedirectToAction("Index", "Announcement", new { area = "Admin" });
            }
            return View(model);
        }
    }
}
