using PostsDAL_EF.Entities;

namespace PostsDAL_EF.Repositories.Interfaces;

public interface IPostRepository : IRepository<Post>
{
    Task<IEnumerable<Post>> GetFullPosts();
    Task<Post> GetFullPost(int id);
    Task<IEnumerable<Post>> GetPostsByUserIdAsync(int userId);
    Task<IEnumerable<Post>> GetPostsByBranchIdAsync(int branchId);
}