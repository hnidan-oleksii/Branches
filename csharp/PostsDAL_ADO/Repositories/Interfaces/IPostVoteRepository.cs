using PostsDAL_ADO.Entities;

namespace PostsDAL_ADO.Repositories.Interfaces;

public interface IPostVoteRepository : IRepository<PostVote>
{
    Task<int> GetVoteCountAsync(int postId);
    Task<PostVote?> GetUserVoteAsync(int postId, int userId);
}
