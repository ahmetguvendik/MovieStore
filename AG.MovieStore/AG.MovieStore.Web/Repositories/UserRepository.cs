using AG.MovieStore.Web.Data.Context;
using AG.MovieStore.Web.Data.Entities.User;
using AG.MovieStore.Web.Interfaces;
using AG.MovieStore.Web.Models.User;
using Microsoft.AspNetCore.Identity;

namespace AG.MovieStore.Web.Repositories
{
    public class UserRepository : IUser
    {
        private readonly UserContext _context;
        private readonly UserManager<ApplicationUser> _usermanager;
        private readonly SignInManager<ApplicationUser> _signinmanager;
        private readonly RoleManager<ApplicationRole> _rolemanager;
        public UserRepository(UserContext context, UserManager<ApplicationUser> usermanager, SignInManager<ApplicationUser> signinmanager, RoleManager<ApplicationRole> rolemanager)
        {
            _context = context;
            _usermanager = usermanager; 
            _signinmanager=signinmanager;
            _rolemanager=rolemanager;
        }
        public async Task<CreateUserModel> CreateUser(CreateUserModel createUser)
        {
            ApplicationUser user = new ApplicationUser()
            {
                UserName = createUser.UserName,
                Email = createUser.UserEmail,
                       
            };
             var result = await _usermanager.CreateAsync(user,createUser.Password);          
           
            
            if (result.Succeeded)
            {
                var role = await _rolemanager.FindByNameAsync("Member");
                if (role == null)
                {
                    await _rolemanager.CreateAsync(new ApplicationRole
                    {
                        Name = "Member"
                    });
                }

                await _usermanager.AddToRoleAsync(user, "Member");
            }
            return createUser;
        }

        public async Task<SignInUserModel> SignIn(SignInUserModel signInUser)
        {
         await _usermanager.FindByNameAsync(signInUser.UserName);

         await _signinmanager.PasswordSignInAsync(signInUser.UserName, signInUser.Password, false, true);
            
            
            return signInUser;
        }

        public async Task SignOutAsync()
        {
            await _signinmanager.SignOutAsync();
        }
    }
}
