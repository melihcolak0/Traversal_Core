using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _71MY_TraversalCore.Areas.Member.Controllers
{
    [Area("Member")]
    public class ReservationController : Controller
    {
        DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());
        ReservationManager reservationManager = new ReservationManager(new EfReservationDal());

        private readonly UserManager<AppUser> _userManager;

        public ReservationController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        
        public async Task<IActionResult> MyReservationsApproved()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = reservationManager.TGetListReservationByApproved(user.Id);
            return View(values);
        }

        public async Task<IActionResult> MyReservationsPast()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = reservationManager.TGetListReservationByPast(user.Id);
            return View(values);
        }

        public async Task<IActionResult> MyReservationsPendingApproval()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = reservationManager.TGetListReservationByPendingApproval(user.Id);
            return View(values);
        }

        [HttpGet]
        public IActionResult NewReservation()
        {
            ViewBag.v1 = "Profil";
            ViewBag.v2 = "Rezervasyon Oluşturma";
            ViewBag.v3 = "/Member/Profile/Index";

            List<SelectListItem> values = (from x in destinationManager.GetList()
                                           select new SelectListItem
                                           {
                                               Text = x.City,
                                               Value = x.DestinationId.ToString()
                                           }).ToList();
            ViewBag.v = values;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NewReservation(Reservation reservation)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            reservation.AppUserId = user.Id;
            reservation.Status = "Onay Bekleniyor";
            reservationManager.TAdd(reservation);
            return RedirectToAction("MyCurrentReservation");
        }
    }
}
