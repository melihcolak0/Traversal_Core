using Microsoft.AspNetCore.Mvc;

namespace _71MY_TraversalCore.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Page404()
        {
            return View();
        }
    }
}
