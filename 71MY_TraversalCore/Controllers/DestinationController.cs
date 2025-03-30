using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace _71MY_TraversalCore.Controllers
{
    [AllowAnonymous]
    [Route("Destination")]
    public class DestinationController : Controller
    {
        DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());
        private readonly UserManager<AppUser> _userManager;

        public DestinationController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            var values = destinationManager.GetList();
            return View(values);
        }

        [Route("DestinationDetails/{id}")]
        [HttpGet]
        public async Task<IActionResult> DestinationDetails(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.v1 = id;

                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                ViewBag.v2 = user.Id;

                var value = destinationManager.TGetDestinationByIdWithGuide(id);
                return View(value);
            }
            else
                return RedirectToAction("LogIn", "LogIn");
                
        }

        [Route("DestinationDetails/{id}")]
        [HttpPost]
        public IActionResult DestinationDetails(Destination destination)
        {
            return View();
        }
    }
}
