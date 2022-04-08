using System.ComponentModel.DataAnnotations.Schema;

namespace AG.MovieStore.Web.Data.Entities.Movies
{
    public class Movie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public int CreatedTime { get; set; }
        public double Score { get; set; }
        public string Director { get; set; }   
    }
}
