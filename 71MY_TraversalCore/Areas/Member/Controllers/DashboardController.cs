using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace _71MY_TraversalCore.Areas.Member.Controllers
{
    [Area("Member")]
    public class DashboardController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public DashboardController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Dashboard";
            ViewBag.v2 = "Dashboard";
            ViewBag.v3 = "/Dashboard/Index";

            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.nameSurname = values.Name + " " + values.Surname;
            ViewBag.memberImage = values.ImageUrl;
            return View();
        }
    }
}
