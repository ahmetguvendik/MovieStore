using System.ComponentModel.DataAnnotations;

namespace AG.MovieStore.Web.Models.User
{
    public class CreateUserModel
    {
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Paralo Eşleşmiyor")]
        public string ConfirmPassword { get; set; }
    }
}
