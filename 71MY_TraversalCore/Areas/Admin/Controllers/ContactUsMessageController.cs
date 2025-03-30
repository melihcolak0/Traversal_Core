using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace _71MY_TraversalCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("/Admin/ContactUsMessage")]
    public class ContactUsMessageController : Controller
    {
        private readonly IContactUsMessageService _contactUsMessageService;

        public ContactUsMessageController(IContactUsMessageService contactUsMessageService)
        {
            _contactUsMessageService = contactUsMessageService;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            var values = _contactUsMessageService.TGetActiveContactUsMessageList();
            return View(values);
        }

        [Route("PassiveContactUsMessage/{id}")]
        public IActionResult PassiveContactUsMessage(int id)
        {
            _contactUsMessageService.TMakeContactUsMessagePassive(id);
            return RedirectToAction("Index", "ContactUsMessage", new { area = "Admin" });
        }
    }
}
