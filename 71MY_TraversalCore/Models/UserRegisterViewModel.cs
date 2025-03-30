using System.ComponentModel.DataAnnotations;

namespace _71MY_TraversalCore.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage ="Lütfen adınızı giriniz!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen soyadınızı giriniz!")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Lütfen kullanıcı adınızı giriniz!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen mail adresinizi giriniz!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lütfen şifrenizi giriniz!")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Lütfen şifrenizi tekrar giriniz!")]
        [Compare("Password", ErrorMessage ="Şifreler uyumlu değil!")]
        public string ConfirmPassword { get; set; }
    }
}
