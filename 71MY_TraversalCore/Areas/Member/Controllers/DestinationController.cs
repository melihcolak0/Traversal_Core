using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _71MY_TraversalCore.Areas.Member.Controllers
{
    [Area("Member")]    
    public class DestinationController : Controller
    {
        DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());
        public IActionResult Index()
        {
            ViewBag.v1 = "Profil"; 
            ViewBag.v2 = "Rotalar";
            ViewBag.v3 = "/Profile/Index";
            var values = destinationManager.GetList();
            return View(values);
        }
    }
}
