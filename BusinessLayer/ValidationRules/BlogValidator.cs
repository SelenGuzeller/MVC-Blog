using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator : AbstractValidator<Blogger>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BloggerName).NotEmpty().WithMessage("Yazar Adını Boş Geçemezsiniz.");
            RuleFor(x => x.BloggerSurName).NotEmpty().WithMessage("Yazar Soyadını Boş Geçemezsiniz.");
            RuleFor(x => x.BloggerAbout).NotEmpty().WithMessage("Hakkımda kısmını boş geçemezsiniz");
        }
    }
}
