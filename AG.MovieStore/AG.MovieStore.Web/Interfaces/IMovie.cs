using AG.MovieStore.Web.Data.Entities.Movies;
using AG.MovieStore.Web.Models.Movie;

namespace AG.MovieStore.Web.Interfaces
{
    public interface IMovie
    {     
        public Task<List<Movie>> GetMovies();
        // public Task<CreateMovieModel> CreateMovie(CreateMovieModel createMovie);
        public Task<Movie> GetMovieById(int id);
        public Task<CreateMovieModel> CreateMovie(CreateMovieModel createMovie);
        public Task RemoveMovie(int id);
        public Task UpdateMovie(UpdateMovieModel updateMovie);

    }
}
