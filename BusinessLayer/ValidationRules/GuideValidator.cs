using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class GuideValidator : AbstractValidator<Guide>
    {
        public GuideValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Rehber adı ve soyadı boş geçilemez!");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama boş geçilemez!");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Görsel Url boş geçilemez!");
            RuleFor(x => x.TwitterUrl).NotEmpty().WithMessage("Twitter Url boş geçilemez!");
            RuleFor(x => x.InstagramUrl).NotEmpty().WithMessage("Instagram Url boş geçilemez!");
            RuleFor(x => x.Name).MinimumLength(10).WithMessage("Rehber adı ve soyadı en az 10 karakter içermelidir!");
            RuleFor(x => x.Name).MaximumLength(40).WithMessage("Rehber adı ve soyadı en fazla 40 karakter içerebilir!");
        }
    }
}
