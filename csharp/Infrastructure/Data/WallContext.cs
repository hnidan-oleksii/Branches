using Application.Common.Interfaces;
using Domain.Entities;
using Infrastructure.Data.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class WallContext : DbContext, IWallContext
{
    public WallContext(DbContextOptions<WallContext> options) : base(options)
    {
    }

	public DbSet<User> Users { get; set; }
	public DbSet<WallPost> WallPosts { get; set; }
	public DbSet<WallComment> WallComments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
		modelBuilder.ApplyConfiguration(new WallPostConfiguration());
		modelBuilder.ApplyConfiguration(new WallCommentConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}
