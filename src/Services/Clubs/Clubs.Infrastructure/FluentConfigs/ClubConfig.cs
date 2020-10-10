using Clubs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clubs.Infrastructure.FluentConfig
{
    internal class ClubConfig : IEntityTypeConfiguration<Club>
    {
        public void Configure(EntityTypeBuilder<Club> entity)
        {
            entity.HasKey(a => a.Id);
            entity.Property(p => p.Id).HasDefaultValueSql("NEWID()");
            entity.Property(p => p.Name).IsRequired();
            entity.Property(p => p.Active).IsRequired().HasDefaultValue(true);
            entity.Property(p => p.Private).IsRequired().HasDefaultValue(false);
        }
    }
}