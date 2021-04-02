using Microsoft.EntityFrameworkCore;
using Models.MovieAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Data
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options): base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
    }
}
