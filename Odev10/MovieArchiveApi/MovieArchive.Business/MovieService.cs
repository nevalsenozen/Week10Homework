using MovieArchive.Data.Models;

namespace MovieArchive.Business
{
    public class MovieService
    {
        private readonly List<Movie> _movies;

        public MovieService()
        {
            // Mini örnek film listesi
            _movies = new List<Movie>
            {
                new Movie { Id = 1, Title = "The Matrix", Year = 1999, Genre = "Action" },
                new Movie { Id = 2, Title = "Inception", Year = 2010, Genre = "Sci-Fi" },
                new Movie { Id = 3, Title = "Titanic", Year = 1997, Genre = "Romance" }
            };
        }

        public List<Movie> GetAllMovies() => _movies;
    }
}