using Account.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Emit;

namespace Data.Account.Mapping;

[ExcludeFromCodeCoverage]
public class UserAccountMapping : IEntityTypeConfiguration<UserAccount>
{
    public void Configure(EntityTypeBuilder<UserAccount> builder)
    {
        builder.ToTable("account");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Username)
            .HasColumnType("varchar(25)")
            .HasColumnName("username")
            .IsRequired();

        builder.Property(x => x.FullName)
            .HasColumnType("varchar(150)")
            .HasColumnName("full_name")
            .IsRequired();

        builder.Property(x => x.Email)
            .HasColumnType("varchar(150)")
            .HasColumnName("email")
            .IsRequired();

        builder.Property(x => x.Password)
            .HasColumnType("varchar(20)")
            .HasColumnName("password")
            .IsRequired();

        builder.Property(x => x.BirthDate)
            .HasColumnType("date")
            .HasColumnName("birth_date")
            .IsRequired();

        builder.Property(x => x.CreatedAt)
            .HasColumnName("created_at")
            .HasColumnType("DATETIME");

        builder.Property(x => x.UpdatedAt)
            .HasColumnName("updated_at")
            .HasColumnType("DATETIME");

        builder.Property(x => x.DeletedAt)
            .HasColumnName("Deleted_At")
            .HasColumnType("DATETIME");

        builder.Property(x => x.IsActive)
            .HasColumnName("is_active")
            .HasColumnType("boolean")
            .IsRequired();

        builder.Property(x => x.IsDeleted)
            .HasColumnName("is_deleted")
            .HasColumnType("boolean")
            .IsRequired();
    }
}