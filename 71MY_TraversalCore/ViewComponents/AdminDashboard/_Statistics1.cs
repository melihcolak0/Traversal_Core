using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace _71MY_TraversalCore.ViewComponents.AdminDashboard
{
    public class _Statistics1 : ViewComponent
    {
        Context context = new Context();
        
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = context.Destinations.Count();
            ViewBag.v2 = context.Users.Count();
            return View();
        }
    }
}
