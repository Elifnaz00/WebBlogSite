using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Validation_Rules
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Bu alanı boş geçmeyiniz");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Bu alanı boş geçmeyiniz");
            RuleFor(x => x.BlogTitle).MinimumLength(3).WithMessage("En az 3 karakterli başlık giriniz");
            RuleFor(x => x.BlogTitle).MaximumLength(100).WithMessage("Karakter sınırını aştınız. En fazla 100 karakter başlık giriniz.");
        }
    }
}
