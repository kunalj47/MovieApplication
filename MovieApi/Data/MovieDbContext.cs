using Microsoft.EntityFrameworkCore;
using MovieApi.Entities;

namespace MovieApi.Data
{
    public class MovieDbContext:DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext>options):base(options)
        {
            
        }
        public DbSet<Movie>Movie { get; set; }

        public DbSet<Person> Person { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
