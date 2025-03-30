using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AboutValidator : AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık kısmı boş geçilemez!");
            RuleFor(x => x.Title2).NotEmpty().WithMessage("Başlık 2 kısmı boş geçilemez!");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama kısmı boş geçilemez!");
            RuleFor(x => x.Description2).NotEmpty().WithMessage("Açıklama 2 kısmı boş geçilemez!");
            RuleFor(x => x.Image1).NotEmpty().WithMessage("Resim Url kısmı boş geçilemez!");
            RuleFor(x => x.Description).MinimumLength(5).WithMessage("Açıklama kısmı 5 karakterden az karakter içeremez!");
            RuleFor(x => x.Description2).MinimumLength(5).WithMessage("Açıklama 2 kısmı 5 karakterden az karakter içeremez!");
            RuleFor(x => x.Description).MaximumLength(500).WithMessage("Açıklama kısmı 500 karakterden fazla karakter içeremez!");
            RuleFor(x => x.Description2).MaximumLength(500).WithMessage("Açıklama 2 kısmı 500 karakterden fazla karakter içeremez!");
        }
    }
}
