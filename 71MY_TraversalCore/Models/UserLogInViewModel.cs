using System.ComponentModel.DataAnnotations;

namespace _71MY_TraversalCore.Models
{
    public class UserLogInViewModel
    {
        [Required(ErrorMessage ="Lütfen kullanıcı adını giriniz!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen şifrenizi giriniz!")]
        public string Password { get; set; }
    }
}
