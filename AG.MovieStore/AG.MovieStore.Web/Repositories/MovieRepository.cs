using AG.MovieStore.Web.Data.Context;
using AG.MovieStore.Web.Data.Entities.Movies;
using AG.MovieStore.Web.Interfaces;
using AG.MovieStore.Web.Models.Movie;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AG.MovieStore.Web.Repositories
{

    public class MovieRepository : IMovie
    {
        private readonly UserContext _context;
        private readonly IMapper _mapper;
        public MovieRepository(UserContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreateMovieModel> CreateMovie(CreateMovieModel createMovie)
        {
            var movie = _context.Movies.SingleOrDefaultAsync(x => x.MovieName == createMovie.MovieName);
            // var movieMapper = _mapper.Map<Movie>(movie);
            if (movie == null)
            {
                var moviee = new Movie();
                moviee.MovieName = createMovie.MovieName;
                moviee.Score = createMovie.Score;
                moviee.CreatedTime = createMovie.CreatedTime;
                moviee.Director = createMovie.Director;
                await _context.Movies.AddAsync(moviee);
                await _context.SaveChangesAsync();
            }
            return createMovie;
        }

        public async Task<Movie> GetMovieById(int id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _context.Movies.SingleOrDefaultAsync(p => p.MovieId == id);
#pragma warning restore CS8603 // Possible null reference return.

        }

        public async Task<List<Movie>> GetMovies()
        {

            return await _context.Movies.ToListAsync();

        }

        public async Task RemoveMovie(int id)
        {
            var removedMovie = await _context.Movies.FindAsync(id);
            _context.Movies.Remove(removedMovie);
            await _context.SaveChangesAsync();

        }

        public async Task UpdateMovie(UpdateMovieModel updateMovie)
        {
            var unchangedEntity = await _context.Movies.FindAsync(updateMovie.Id);
            if (unchangedEntity != null)
            {
                unchangedEntity.Director = string.IsNullOrEmpty(updateMovie.Director) ? unchangedEntity.Director : updateMovie.Director;
                unchangedEntity.MovieName = string.IsNullOrEmpty(updateMovie.MovieName) ? unchangedEntity.MovieName : updateMovie.MovieName;
                unchangedEntity.Score = updateMovie.Score != default ? updateMovie.Score : unchangedEntity.Score;
                //  unchangedEntity.MovieId = updateMovie.MovieId != default ? updateMovie.MovieId : unchangedEntity.MovieId;
            }
            await _context.SaveChangesAsync();
        }
    }
}
