using AG.MovieStore.Web.Data.Configurations;
using AG.MovieStore.Web.Data.Entities.Movies;
using AG.MovieStore.Web.Data.Entities.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AG.MovieStore.Web.Data.Context
{
    public class UserContext : IdentityDbContext<ApplicationUser , ApplicationRole, int>
    {
        public DbSet<Movie> Movies { get; set; }
        public UserContext(DbContextOptions<UserContext> options) : base(options ) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new MovieConfiguration());
            base.OnModelCreating(builder);
        }

    }

}
