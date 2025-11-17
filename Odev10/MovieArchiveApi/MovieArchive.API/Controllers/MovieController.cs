using Microsoft.AspNetCore.Mvc;
using MovieArchive.Business;
using MovieArchive.Data.Models;

namespace MovieArchive.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly MovieService _service;

        public MoviesController()
        {
            _service = new MovieService();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var movies = _service.GetAllMovies();
            return Ok(movies);
        }
    }
}