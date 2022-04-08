using AG.MovieStore.Web.Data.Entities.Movies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AG.MovieStore.Web.Data.Configurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.Property(x=>x.MovieName).IsRequired(true);
        builder.Property(x=>x.Director).IsRequired(true);
        builder.Property(x=>x.CreatedTime).IsRequired(true);
        builder.Property(x=>x.Score).IsRequired(true);
            builder.HasData(new Movie[]
            {
          
                new Movie{MovieId=5,MovieName="Başlangıç",Score=8.9,Director="Christopher Nolan"  },
                new Movie{MovieId=6,MovieName="Başlangıç",Score=8.9,Director="Christopher Nolan"  },
                new Movie{MovieId=7,MovieName="Başlangıç",Score=8.9,Director="Christopher Nolan"  }
            }
            );
    }
}
    }