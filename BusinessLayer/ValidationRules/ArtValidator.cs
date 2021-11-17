using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
   public class ArtValidator:AbstractValidator<Art>
    {
        public ArtValidator()
        {
            RuleFor(x => x.ArtName).NotEmpty().WithMessage("Başlık Boş Geçemezsiniz.");
            RuleFor(x => x.ArtDescription).NotEmpty().WithMessage("Açıklama Boş Geçilemez.");
            //RuleFor(x => x.CategoryID).NotEmpty().WithMessage("Kategori Adını Boş Geçemezsiniz.");
            //RuleFor(x => x.TypeID).NotEmpty().WithMessage("Kategori Tür Adını Boş Geçemezsiniz.");
           
            
        }
    }
}
