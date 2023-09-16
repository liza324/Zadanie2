using AdvancedProgramming_Lesson1.Models;
using Microsoft.EntityFrameworkCore;

namespace AdvancedProgramming_Lesson1.Data
{
    public class MvcMovieContext : DbContext
    {
        public MvcMovieContext(DbContextOptions<MvcMovieContext> options)
        : base(options)
        {
        }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Alcohols> Alcohols { get; set; }
        public DbSet<Meat> Meat { get; set; }
        public DbSet<Authors> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<AuthorsBooks> AuthorsBooks { get; set; }
        public DbSet<DairtyProducts> DairtyProducts { get; set; }
        public DbSet<Drinks> Drinks { get; set; }
        public DbSet<Glasses> Glasses { get; set; }
        public DbSet<Knives> Knives { get; set; }
        public DbSet<LiteraryGenres> LiteraryGenres { get; set; }
        public DbSet<Pots> Pots { get; set; }
        public DbSet<Shoes> Shoes { get; set; }



    }
}
