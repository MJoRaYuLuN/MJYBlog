using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adı soyadı kısmı boş geçilemez");
            RuleFor(x => x.WriterEmail).NotEmpty().WithMessage("E-Posta adresi boş geçilemez");
            RuleFor(x => x.WriterEmail).EmailAddress().WithMessage("Geçerli bir e-posta adresi girin");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifre boş geçilemez");
            RuleFor(x => x.WriterPassword).Length(2, 200).Matches(@"[A-Z]+").WithMessage("Şifreniz en az iki büyük karakter içermelidir.");
            RuleFor(x => x.WriterPassword).Length(2, 200).Matches(@"[a-z]+").WithMessage("Şifreniz en az iki küçük karakter içermelidir.");
            RuleFor(x => x.WriterPassword).Length(2, 200).Matches(@"[0-9]+").WithMessage("Şifreniz en az iki rakam içermelidir.");
            RuleFor(x => x.WriterPassword).Matches(@"[\!\?\*\.]+").WithMessage("Şifreniz en az bir adet (!? *.) karakterlerinden içermelidir.");
            RuleFor(x => x.WriterPasswordConfirm).NotEmpty().WithMessage("Şifre boş geçilemez");
            RuleFor(x => x.WriterPasswordConfirm).Length(2, 200).Matches(@"[A-Z]+").WithMessage("Şifreniz en az iki büyük karakter içermelidir.");
            RuleFor(x => x.WriterPasswordConfirm).Length(2, 200).Matches(@"[a-z]+").WithMessage("Şifreniz en az iki küçük karakter içermelidir.");
            RuleFor(x => x.WriterPasswordConfirm).Length(2, 200).Matches(@"[0-9]+").WithMessage("Şifreniz en az iki rakam içermelidir.");
            RuleFor(x => x.WriterPasswordConfirm).Matches(@"[\!\?\*\.]+").WithMessage("Şifreniz en az bir adet (!? *.) karakterlerinden içermelidir.");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Lütfen en az iki karakter girişi yapın");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Lütfen en fazla elli karakter girişi yapın");
            RuleFor(x => x).Custom((x, context) =>
            {
                if (x.WriterPassword != x.WriterPasswordConfirm)
                {
                    context.AddFailure(nameof(x.WriterPassword), "Şifreler birbirleri ile uyuşmuyor");
                }
            });
        }
    }
}
