using Clubs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clubs.Infrastructure.FluentConfig
{
    internal class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity.HasKey(a => a.Id);
            entity.Property(p => p.Id).HasDefaultValueSql("NEWID()");
            entity.Property(p => p.ObjectId).IsRequired();
            entity.Property(p => p.Email).IsRequired();
            entity.Property(p => p.DisplayName).IsRequired();
        }
    }
}