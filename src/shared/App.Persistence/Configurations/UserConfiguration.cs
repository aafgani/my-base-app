using App.Domain.Entities.Users;
using App.Domain.Ids;
using App.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Persistence.Configurations;

internal class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");

        builder.Ignore(x => x.DomainEvents);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion(
                v => v.Value,
                v => new UserId(v)
            )
            .ValueGeneratedNever()
            .IsRequired();

        builder.Property(x => x.Username)
            .HasConversion(
                v => v.Value,
                v => new Username(v)
            )
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.Email)
            .HasConversion(
                v => v.Value,
                v => new Email(v)
            )
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.PasswordHash)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(x => x.IsActive)
            .HasDefaultValue(false);

        builder.Property(x => x.FailedLoginAttempts)
            .HasDefaultValue(0);

        builder.Property(x => x.LockUntil)
            .HasDefaultValue(null);

        builder.HasIndex(x => x.Email)
            .IsUnique();

        builder.Property(x => x.CreatedAt)
            .IsRequired();

        builder.Property(x => x.UpdatedAt)
            .IsRequired();

        builder.OwnsMany(
            x => x.Roles,
            roleBuilder =>
            {
                roleBuilder.Property(x => x.RoleId)
                    .HasConversion(
                        v => v.Value,
                        v => new RoleId(v)
                    )
                    .IsRequired();

                roleBuilder.HasKey("UserId", "RoleId");
            });

    }
}
