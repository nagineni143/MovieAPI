using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.MovieAPI;
using MovieAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MovieDbContext _context;

        public MoviesController(MovieDbContext context)
        {
            _context = context;
        }

        // GET: api/<MoviesController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Movies);
            
        }

        // GET api/<MoviesController>/5
        [HttpGet("{id}")]
        public Movie Get(int id)
        {
            return _context.Movies.FirstOrDefault(movie =>movie.Id == id);
        }

        // POST api/<MoviesController>
        [HttpPost]
        public void Post([FromBody] Movie value)
        {
            _context.Movies.Add(value);
            _context.SaveChanges();
        }

        // PUT api/<MoviesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Movie value)
        {
            var movie = _context.Movies.FirstOrDefault(v => v.Id == id);
            movie.Id = value.Id;
            movie.Name = value.Name;
            movie.Language = value.Language;
            _context.SaveChanges();
        }

        // DELETE api/<MoviesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _context.Movies.Remove(_context.Movies.FirstOrDefault(v => v.Id == id));
            _context.SaveChanges();
        }
    }
}
