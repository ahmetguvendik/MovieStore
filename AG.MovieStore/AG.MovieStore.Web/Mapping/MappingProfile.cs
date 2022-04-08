using AG.MovieStore.Web.Data.Entities.Movies;
using AG.MovieStore.Web.Models.Movie;
using AutoMapper;

namespace AG.MovieStore.Web.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Movie, CreateMovieModel>();
            CreateMap<CreateMovieModel, Movie>();
            CreateMap<UpdateMovieModel, Movie>();
            CreateMap<Movie, UpdateMovieModel>();
        }
    }
}
