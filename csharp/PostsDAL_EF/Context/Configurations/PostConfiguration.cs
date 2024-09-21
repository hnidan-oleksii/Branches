using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PostsDAL_EF.Entities;

namespace PostsDAL_EF.Context.Configurations;

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.ToTable("posts");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.BranchId)
            .HasColumnName("branchid")
            .IsRequired();

        builder.Property(e => e.UserId)
            .HasColumnName("userid")
            .IsRequired();

        builder.Property(e => e.Title)
            .HasColumnName("title")
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(e => e.Content)
            .HasColumnName("content");

        builder.Property(e => e.CreatedAt)
            .HasColumnName("createdat")
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.HasOne(p => p.User)
            .WithMany(u => u.Posts)
            .HasForeignKey(p => p.UserId);

        builder.HasOne(p => p.Branch)
            .WithMany(b => b.Posts)
            .HasForeignKey(p => p.BranchId);
    }
}