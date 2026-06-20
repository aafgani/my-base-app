using App.Domain.Entities.Roles;
using App.Domain.Ids;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Persistence.Configurations;

internal class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Role");

        builder.Ignore(x => x.DomainEvents);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion(
                v => v.Value,
                v => new RoleId(v)
            )
            .ValueGeneratedNever()
            .IsRequired();

        builder.Property(x => x.Name)
       .IsRequired();
    }
}
