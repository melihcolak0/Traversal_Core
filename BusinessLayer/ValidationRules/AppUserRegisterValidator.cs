using DTOLayer.DTOs.AppUserDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterDTO>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen adınızı giriniz!");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Lütfen soyadınızı giriniz!");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Lütfen kullanıcı adınızı giriniz!");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Lütfen mail adresinizi giriniz!");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Lütfen şifrenizi giriniz!");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Lütfen şifrenizi tekrar giriniz!");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Adınız en az 3 karakter içermelidir!");
            RuleFor(x => x.Name).MaximumLength(20).WithMessage("Adınız en fazla 20 karakter içerebilir!");
            RuleFor(x => x.Password).Equal(y => y.ConfirmPassword).WithMessage("Şifreler aynı olmalıdır!");
        }
    }
}
