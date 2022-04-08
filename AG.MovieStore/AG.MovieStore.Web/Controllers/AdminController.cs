using AG.MovieStore.Web.Data.Entities.Movies;
using AG.MovieStore.Web.Interfaces;
using AG.MovieStore.Web.Models.Movie;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AG.MovieStore.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IMovie _movie;
        private readonly IMapper _mapper;
        public AdminController(IMovie movie, IMapper mapper)
        {
            _mapper = mapper;
            _movie = movie;
        }
        public async Task<IActionResult> IndexAsync()
        {
            var movies = await _movie.GetMovies();
            return View(movies);
        }

        public IActionResult Create()
        {
            return View(new CreateMovieModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMovieModel model)
        {
           var createdMovie = await _movie.CreateMovie(model);
            return View(createdMovie);
        }

        public async Task<IActionResult> Remove(int id)
        {
            await _movie.RemoveMovie(id);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var movie = await _movie.GetMovieById((int)id);
            var movieMapper = _mapper.Map<UpdateMovieModel>(movie);
            if (movieMapper == null)
            {
                return View();
            }
            return View(movieMapper);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateMovieModel movie)
        {
            await _movie.UpdateMovie(movie);
            return Json("");
        }


    }
}
