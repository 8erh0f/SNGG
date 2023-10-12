using Microsoft.EntityFrameworkCore;
using SNGG.Models.Entities;

namespace SNGG.DataAccess
{
    public class SNGGContext : DbContext
    {
        public SNGGContext(DbContextOptions<SNGGContext> options) : base(options)
        {
        }

        public required DbSet<Game> Games { get; set; }
        public required DbSet<Guess> Guesses { get; set; }
        public required DbSet<Player> Players { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}