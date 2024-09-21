using PostsDAL_EF.Entities;

namespace PostsDAL_EF.Repositories.Interfaces;

public interface IPostVoteRepository : IRepository<PostVote>
{
    Task<int> GetVoteCountAsync(int postId);
    Task<PostVote?> GetUserVoteAsync(int postId, int userId);
}