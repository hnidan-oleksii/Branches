using Microsoft.EntityFrameworkCore;
using PostsDAL_EF.Context;
using PostsDAL_EF.Entities;
using PostsDAL_EF.Repositories.Interfaces;

namespace PostsDAL_EF.Repositories;

public class PostRepository : Repository<Post>, IPostRepository
{
    public PostRepository(PostsContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Post>> GetFullPosts()
    {
        return await _table
            .Include(p => p.Votes)
            .Include(p => p.Branch)
            .Include(p => p.User)
            .ToListAsync();
    }

    public async Task<Post> GetFullPost(int id)
    {
        return await _table
                   .Include(p => p.Votes)
                   .Include(p => p.User)
                   .Include(p => p.Branch)
                   .FirstOrDefaultAsync(p => p.Id == id)
               ?? throw new KeyNotFoundException($"Post with id {id} could not be found");
    }

    public async Task<IEnumerable<Post>> GetPostsByUserIdAsync(int userId)
    {
        return await _table.Where(p => p.UserId == userId)
            .Include(p => p.Votes)
            .Include(p => p.Branch)
            .Include(p => p.User)
            .ToListAsync();
    }

    public async Task<IEnumerable<Post>> GetPostsByBranchIdAsync(int branchId)
    {
        return await _table.Where(p => p.BranchId == branchId)
            .Include(p => p.Votes)
            .Include(p => p.Branch)
            .Include(p => p.User)
            .ToListAsync();
    }
}