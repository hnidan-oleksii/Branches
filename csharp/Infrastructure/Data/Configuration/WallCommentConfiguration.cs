using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class WallCommentConfiguration : IEntityTypeConfiguration<WallComment>
{
    public void Configure(EntityTypeBuilder<WallComment> builder)
    {
        builder.HasKey(wc => wc.Id);

        builder.Property(wc => wc.Content)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(wc => wc.CreatedAt)
            .IsRequired()
			.HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(wc => wc.AuthorUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<WallPost>()
            .WithMany(wp => wp.Comments)
            .HasForeignKey(wc => wc.PostId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

