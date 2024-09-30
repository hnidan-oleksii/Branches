using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces;

public interface IWallContext
{
    DbSet<User> Users { get; set; }
    DbSet<WallPost> WallPosts { get; set; }
    DbSet<WallComment> WallComments { get; set; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}