using AG.MovieStore.Web.Interfaces;
using AG.MovieStore.Web.Models.User;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace AG.MovieStore.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IValidator<CreateUserModel> _createUserValidator;
        private readonly IValidator<SignInUserModel> _signInValidator;
        private readonly IUser _user;

        public UserController(IValidator<CreateUserModel> createUserValidator,IUser user, IValidator<SignInUserModel> signInValidator)
        {
            _createUserValidator = createUserValidator;
            _user = user;
            _signInValidator = signInValidator;
        }
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateUserModel model)
        {
            try
            {
               _createUserValidator.ValidateAndThrow(model);
                if (ModelState.IsValid)
                {
                    await _user.CreateUser(model);
                    return RedirectToAction("Index","Home");
                }
                            
            }

            catch(Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }
      

            return View();
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
         public async Task<IActionResult> SignIn(SignInUserModel model)
        {
            try
            {
                 _signInValidator.ValidateAndThrow(model);
                if (ModelState.IsValid)
                {
                                     
                    await _user.SignIn(model);
                    return RedirectToAction("Index", "Home");
                }
            }
            
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;

            }
            return View();   
        }

        public IActionResult SignOut()
        {
            _user.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}
