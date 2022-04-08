using AG.MovieStore.Web.Models.User;
using FluentValidation;

namespace AG.MovieStore.Web.Validations
{
    public class SignInValidation : AbstractValidator<SignInUserModel>
    {
        public SignInValidation()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Lütfen Kullanıcı Adınızı Giriniz");        
            RuleFor(x => x.Password).NotEmpty().WithMessage("Lütfen Şifrenizi Giriniz");
                
        }
    }
}
