using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PostsDAL_EF.Entities;

namespace PostsDAL_EF.Context.Configurations;

public class PostVoteConfiguration : IEntityTypeConfiguration<PostVote>
{
    public void Configure(EntityTypeBuilder<PostVote> builder)
    {
        builder.ToTable("postvotes", t =>
        {
            t.HasCheckConstraint("CK_PostVotes_VoteType", "votetype IN (-1, 1)");
        });

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.PostId)
            .HasColumnName("postid")
            .IsRequired();

        builder.Property(e => e.UserId)
            .HasColumnName("userid")
            .IsRequired();

        builder.Property(e => e.VoteType)
            .HasColumnName("votetype")
            .IsRequired();

        builder.Property(e => e.VotedAt)
            .HasColumnName("votedat")
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.HasOne(d => d.Post)
            .WithMany(p => p.Votes)
            .HasForeignKey(d => d.PostId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(d => d.User)
            .WithMany(u => u.PostVotes)
            .HasForeignKey(d => d.UserId);

        builder.HasIndex(e => new { e.PostId, e.UserId })
            .IsUnique();
    }
}