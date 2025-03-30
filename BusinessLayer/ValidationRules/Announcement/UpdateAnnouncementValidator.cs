using DTOLayer.DTOs.AnnouncementDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.Announcement
{
    public class UpdateAnnouncementValidator : AbstractValidator<UpdateAnnouncementDTO>
    {
        public UpdateAnnouncementValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Lütfen başlığı giriniz!");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Lütfen başlığı giriniz!");
            RuleFor(x => x.Title).MinimumLength(3).WithMessage("Başlık en az üç karater olmalıdır!");
            RuleFor(x => x.Content).MinimumLength(3).WithMessage("İçerik en az üç karakter olmalıdır!");
            RuleFor(x => x.Title).MaximumLength(30).WithMessage("Başlık en fazla üç karater alabilir!");
            RuleFor(x => x.Content).MaximumLength(500).WithMessage("İçerik en fazla üç karakter alabilir!");
        }
    }
}
