using AG.MovieStore.Web.Models.User;
using FluentValidation;

namespace AG.MovieStore.Web.Validations
{
    public class CreateUserValidation : AbstractValidator<CreateUserModel>
    {
            public CreateUserValidation()
        {
                RuleFor(x=> x.UserName).NotEmpty().WithMessage("Lütfen Kullanıcı Adınızı Giriniz");
                
                RuleFor(x=> x.UserEmail).NotEmpty().WithMessage("Lütfen Email Adresinizi Giriniz");
                RuleFor(x=> x.Password).NotEmpty().WithMessage("Lütfen Şifrenizi Giriniz");
                RuleFor(x=> x.ConfirmPassword).NotEmpty().WithMessage("Lütfen Şifrenizi Tekrar Giriniz");
                

                RuleFor(x => x.UserEmail).EmailAddress().WithMessage("Lütfen Doğru Formatta Giriniz");
        }
    }
}
