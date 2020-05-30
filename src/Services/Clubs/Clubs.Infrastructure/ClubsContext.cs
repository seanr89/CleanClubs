using Microsoft.EntityFrameworkCore;
using Clubs.Domain.Entities;

namespace Clubs.Infrastructure
{
    public class ClubsContext : DbContext
    {
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Player> Players { get; set; }


        public ClubsContext(DbContextOptions<ClubsContext> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Club>()
                .HasMany(c => c.Players)
                .WithOne(e => e.Club);
        }
    }
}
