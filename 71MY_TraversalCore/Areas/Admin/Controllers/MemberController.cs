using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace _71MY_TraversalCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MemberController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly IReservationService _reservationService;

        public MemberController(IAppUserService appUserService, IReservationService reservationService)
        {
            _appUserService = appUserService;
            _reservationService = reservationService;
        }

        public IActionResult Index()
        {
            var values = _appUserService.GetList();
            return View(values);
        }

        public IActionResult DeleteMember(int id)
        {
            var value = _appUserService.TGetById(id);
            _appUserService.TDelete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateMember(int id)
        {
            var value = _appUserService.TGetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateMember(AppUser appUser)
        {
            _appUserService.TUpdate(appUser);
            return RedirectToAction("Index");
        }

        public IActionResult GetMemberComments(int id)
        {
            var values = _appUserService.GetList();
            return View(values);
        }

        public IActionResult GetMemberReservationHistory(int id)
        {
            var values = _reservationService.TGetListReservationByPast(id);
            return View(values);
        }
    }
}
