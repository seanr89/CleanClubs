using Microsoft.EntityFrameworkCore;
using Clubs.Domain.Entities;
using System.Threading;
using Clubs.Domain.Common;
using System;
using System.Threading.Tasks;

namespace Clubs.Infrastructure
{
    public class ClubsContext : DbContext
    {
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Invite> Invites { get; set; }

        public ClubsContext()
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }


        public ClubsContext(DbContextOptions<ClubsContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Club>()
                .HasMany(c => c.Members)
                .WithOne(e => e.Club);
            modelBuilder.Entity<Club>()
                .HasMany(c => c.Matches)
                .WithOne(e => e.Club);
            modelBuilder.Entity<Match>()
                .HasMany(c => c.Teams)
                .WithOne(e => e.Match);
            modelBuilder.Entity<Match>()
                .HasMany(c => c.Invites)
                .WithOne(e => e.Match);
            modelBuilder.Entity<Team>()
                .HasMany(c => c.Players)
                .WithOne(e => e.Team);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        //entry.Entity.Created = _dateTime.Now;
                        break;
                    case EntityState.Modified:
                        //entry.Entity.LastModified = _dateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
