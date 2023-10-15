using Microsoft.EntityFrameworkCore;
using SNGG.DataAccess.Configurations;
using SNGG.Models.Dto;
using SNGG.Models.Entities;

namespace SNGG.DataAccess
{
    public class SNGGContext : DbContext
    {
        public SNGGContext(DbContextOptions<SNGGContext> options) : base(options)
        {
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Guess> Guesses { get; set; }
        public DbSet<Player> Players { get; set; }

        public DbSet<GuessesPerDigitCountDto> GuessesPerDigitCountDtos { get; set; }
        public DbSet<EntrySpeedPerUserDto> EntrySpeedPerUserDtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GuessesPerDigitCountDtoConfiguration());
            modelBuilder.ApplyConfiguration(new EntrySpeedPerUserDtoConfiguration());
        }
    }
}