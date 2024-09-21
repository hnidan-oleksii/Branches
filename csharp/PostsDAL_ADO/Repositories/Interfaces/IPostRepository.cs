using PostsDAL_ADO.Entities;

namespace PostsDAL_ADO.Repositories.Interfaces;

public interface IPostRepository : IRepository<Post>
{
    Task<IEnumerable<Post>> GetPostsByUserIdAsync(int userId);
    Task<IEnumerable<Post>> GetPostsByBranchIdAsync(int branchId);
}
