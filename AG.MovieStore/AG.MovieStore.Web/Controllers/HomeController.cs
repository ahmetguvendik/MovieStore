using Microsoft.AspNetCore.Mvc;

namespace AG.MovieStore.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
