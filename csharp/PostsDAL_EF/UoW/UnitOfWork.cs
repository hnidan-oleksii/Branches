using Microsoft.EntityFrameworkCore.Storage;
using PostsDAL_EF.Context;
using PostsDAL_EF.Repositories;
using PostsDAL_EF.Repositories.Interfaces;

namespace PostsDAL_EF.UoW;

public class UnitOfWork : IUnitOfWork
{
    private readonly PostsContext _context;
    private IPostRepository? _posts;
    private IPostVoteRepository? _postVotes;
    private IBranchRepository _branches;
    private IDbContextTransaction _transaction;

    public UnitOfWork(PostsContext context)
    {
        _context = context;
    }

    public PostsContext Context => _context;
    public IPostRepository Posts => _posts ??= new PostRepository(_context);
    public IPostVoteRepository PostVotes => _postVotes ??= new PostVoteRepository(_context);
    public IBranchRepository Branches => _branches ??= new BranchRepository(_context);

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public async Task BeginTransactionAsync()
    {
        _transaction = await _context.Database.BeginTransactionAsync();
    }

    public async Task CommitTransactionAsync()
    {
        await _transaction.CommitAsync();
    }

    public async Task RollbackTransactionAsync()
    {
        await _transaction.RollbackAsync();
    }

    public void Dispose()
    {
        _transaction?.Dispose();
        _context.Dispose();
    }
}