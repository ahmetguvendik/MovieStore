using AG.MovieStore.Web.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AG.MovieStore.Web.Controllers
{
    [Authorize(Roles = "Member")]
    public class MemberController : Controller
    {
        private readonly IMovie _movie;
        public MemberController(IMovie movie)
        {
            _movie = movie;
        }
        public async Task<IActionResult> Index()
        {
            
           var movies = await _movie.GetMovies();
            return View(movies);
        }
    
        public IActionResult Detail()
        {
            return View();
        }

    }
}
