using WallsDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WallsInfrastructure.Data.Configuration;

public class WallPostConfiguration : IEntityTypeConfiguration<WallPost>
{
    public void Configure(EntityTypeBuilder<WallPost> builder)
    {
        builder.HasKey(wp => wp.Id);

        builder.Property(wp => wp.Content)
            .IsRequired()
            .HasMaxLength(1000);

        builder.Property(wp => wp.CreatedAt)
            .IsRequired()
			.HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(wp => wp.AuthorUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(wp => wp.ProfileUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(wp => wp.Comments)
            .WithOne()
            .HasForeignKey(c => c.PostId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

