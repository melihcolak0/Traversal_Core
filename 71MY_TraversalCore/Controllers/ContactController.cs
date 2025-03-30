using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.DTOs.ContactDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace _71MY_TraversalCore.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        private readonly IContactUsMessageService _contactUsMessageService;
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactUsMessageService contactUsMessageService, IMapper mapper, IContactService contactService)
        {
            _contactService = contactService;
            _contactUsMessageService = contactUsMessageService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var values = _contactService.GetList();
            ViewBag.contactInformations = values;
            return View();
        }

        [HttpPost]
        public IActionResult Index(SendMessageDTO model)
        {
            if (ModelState.IsValid)
            {
                _contactUsMessageService.TAdd(new ContactUsMessage
                {
                    Name = model.Name,
                    Mail = model.Mail,
                    Subject = model.Subject,
                    MessageContent = model.MessageContent,
                    MessageDate = DateTime.Now,
                    Status = true
                });
                return RedirectToAction("Index", "Contact");
            }
            ViewBag.contactInformations = _contactService.GetList();
            return View(model);            
        }
    }
}
