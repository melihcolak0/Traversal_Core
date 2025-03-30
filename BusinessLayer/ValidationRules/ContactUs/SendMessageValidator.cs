using DTOLayer.DTOs.ContactDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.ContactUs
{
    public class SendMessageValidator : AbstractValidator<SendMessageDTO>
    {
        public SendMessageValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim boş geçilemez!");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail boş geçilemez!");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu boş geçilemez!");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesaj boş geçilemez!");

            RuleFor(x => x.Name).MinimumLength(3).WithMessage("İsim en az 3 karakter olmalıdır!");
            RuleFor(x => x.Name).MaximumLength(100).WithMessage("İsim en fazla 100 karakter olabilir!");

            RuleFor(x => x.Mail).EmailAddress().WithMessage("Bir Mail adresi giriniz!");
        }
    }
}
