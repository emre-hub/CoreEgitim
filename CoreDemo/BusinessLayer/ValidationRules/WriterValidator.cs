using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        //Bu kısımdaki Validation'ları çalıştırmak için RegisterController sınıfında çağıracağız.
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adı-Soyadı kısmı boş geçilemez.");   
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail adresi kısmı boş geçilemez.");
            //Fluent Validationda Kullanıcının parolası
            //en az bir büyük harf, en az bir küçük harf ve en az 1 sayı olacak.
            //Ayarla.
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifre kısmı boş geçilemez.");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter girişi yapınız.");  
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakterlik veri girişi yapınız.");  
        }
    }
}
