using Microsoft.EntityFrameworkCore;
using PostsDAL_EF.Context;
using PostsDAL_EF.Entities;
using PostsDAL_EF.Repositories.Interfaces;

namespace PostsDAL_EF.Repositories;

public class PostVoteRepository : Repository<PostVote>, IPostVoteRepository
{
    public PostVoteRepository(PostsContext context) : base(context)
    {
    }

    public async Task<int> GetVoteCountAsync(int postId)
    {
        return await _table.Where(v => v.PostId == postId).SumAsync(v => v.VoteType);
    }

    public async Task<PostVote?> GetUserVoteAsync(int postId, int userId)
    {
        return await _table.SingleOrDefaultAsync(v => v.PostId == postId && v.UserId == userId);
    }
}