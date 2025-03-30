using _71MY_TraversalCore.Areas.Member.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace _71MY_TraversalCore.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[controller]/[action]")]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Dashboard";
            ViewBag.v2 = "Profil";
            ViewBag.v3 = "/Profile/Index";

            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            MemberProfileViewModel memberProfileViewModel = new MemberProfileViewModel();
            memberProfileViewModel.Name = values.Name;
            memberProfileViewModel.Surname = values.Surname;
            memberProfileViewModel.PhoneNumber = values.PhoneNumber;
            memberProfileViewModel.Email = values.Email;
            memberProfileViewModel.ImageUrl = values.ImageUrl;
            return View(memberProfileViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(MemberProfileViewModel p)
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);

            if(p.Image != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(p.Image.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/MemberImages/" + imageName;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await p.Image.CopyToAsync(stream);
                value.ImageUrl = imageName;
            }

            value.Name = p.Name;
            value.Surname = p.Surname;
            value.PasswordHash = _userManager.PasswordHasher.HashPassword(value, p.Password);
            var result = await _userManager.UpdateAsync(value);

            if(result.Succeeded)
            {
                return RedirectToAction("LogIn", "LogIn");
            }
            return View();
        }
    }
}
