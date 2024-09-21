using Microsoft.EntityFrameworkCore;
using PostsDAL_EF.Entities;
using PostsDAL_EF.Context.Configurations;

namespace PostsDAL_EF.Context;

public class PostsContext : DbContext
{
    public PostsContext(DbContextOptions<PostsContext> options) : base(options)
    {
    }

    public DbSet<Post> Posts { get; set; }
    public DbSet<PostVote> PostVotes { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Branch> Branches { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PostConfiguration());
        modelBuilder.ApplyConfiguration(new PostVoteConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new BranchConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}