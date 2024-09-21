using PostsDAL_ADO.Repositories.Interfaces;

namespace PostsDAL_ADO.UoW;

public interface IUnitOfWork : IDisposable
{
    IPostRepository Posts { get; }
    IPostVoteRepository PostVotes { get; }
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
}