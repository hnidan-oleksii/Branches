using PostsDAL_EF.Context;
using PostsDAL_EF.Repositories.Interfaces;

namespace PostsDAL_EF.UoW;

public interface IUnitOfWork : IDisposable
{
    PostsContext Context { get; }
    IPostRepository Posts { get; }
    IPostVoteRepository PostVotes { get; }
    Task<int> SaveChangesAsync();
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
}