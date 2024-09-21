using System.Data;
using PostsDAL_ADO.Repositories.Interfaces;

namespace PostsDAL_ADO.UoW;

public class UnitOfWork : IUnitOfWork
{
    private IDbTransaction _dbTransaction;

    public IPostRepository Posts { get; private set; }
    public IPostVoteRepository PostVotes { get; private set; }

    public UnitOfWork(IDbTransaction dbDbTransaction,
        IPostRepository postRepository,
        IPostVoteRepository postVoteRepository)
    {
        _dbTransaction = dbDbTransaction;
        Posts = postRepository;
        PostVotes = postVoteRepository;
    }

    public async Task CommitTransactionAsync()
    {
        try
        {
            await Task.Run(() => _dbTransaction.Commit());
        }
        catch (Exception ex)
        {
            await RollbackTransactionAsync();
        }
    }

    public async Task RollbackTransactionAsync()
    {
        await Task.Run(() => _dbTransaction.Rollback());
    }

    public void Dispose()
    {
        _dbTransaction.Connection?.Close();
        _dbTransaction.Connection?.Dispose();
        _dbTransaction.Dispose();
    }
}