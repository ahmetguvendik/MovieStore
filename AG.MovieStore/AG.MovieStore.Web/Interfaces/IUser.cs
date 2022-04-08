using AG.MovieStore.Web.Models.User;

namespace AG.MovieStore.Web.Interfaces
{
    public interface IUser
    {
        public Task<CreateUserModel> CreateUser(CreateUserModel createUser);

        public Task<SignInUserModel> SignIn(SignInUserModel signInUserModel);

        public Task SignOutAsync();
    }
}
