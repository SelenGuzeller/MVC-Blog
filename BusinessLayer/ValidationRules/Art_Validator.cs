using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
   public class Art_Validator:AbstractValidator<Art>
    {
        public Art_Validator()
        {
            RuleFor(x => x.ArtName).NotEmpty().WithMessage("Başlık Boş Geçemezsiniz.");
            RuleFor(x => x.ArtDescription).NotEmpty().WithMessage("Açıklama Boş Geçilemez.");
        }
    }
}
