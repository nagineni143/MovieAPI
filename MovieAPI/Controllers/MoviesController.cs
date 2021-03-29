using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.MovieAPI;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private static List<Movie> movies = new List<Movie>()
        {
            new Movie() { Id = 1, Name = "The Godfather", Language = "English"},
            new Movie() { Id = 2, Name = "RRR", Language = "Telugu"},
            new Movie() { Id = 3, Name = "Fanna", Language = "Hindi"}
        };

        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            return movies;
        }
        [HttpPost]
        public void Post([FromBody]Movie movie)
        {
            movies.Add(movie);
        }
        [HttpPut("{id}")]
        public void Put(int id,[FromBody] Movie movie)
        {
            var updateMovie = movies.FirstOrDefault(movieId => movieId.Id == id);
            updateMovie.Id = movie.Id;
            updateMovie.Name = movie.Name;
            updateMovie.Language = movie.Language;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            movies.RemoveAt(id);
        }
    }
}
