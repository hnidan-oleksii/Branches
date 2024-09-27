using System.Data;
using Branches_DAL.Repositories.Interfaces;
using Branches_DAL.UoW.Interfaces;
using Npgsql;

namespace Branches_DAL.UoW;

public class UnitOfWork : IUnitOfWork
{
    private readonly NpgsqlConnection _connection;
    private IDbTransaction _transaction;
    public IBranchRepository Branches { get; private set; }
    public IBranchMemberRepository BranchMembers { get; private set; }
    
    public UnitOfWork(NpgsqlConnection connection,
        IDbTransaction transaction,
        IBranchRepository branchRepository,
        IBranchMemberRepository branchMemberRepository)
    {
        _connection = connection;
        _transaction = transaction;
        Branches = branchRepository;
        BranchMembers = branchMemberRepository;
    }

    public async Task CommitAsync()
    {
        await Task.Run(() => _transaction?.Commit());
    }

    public async Task RollbackAsync()
    {
        await Task.Run(() => _transaction?.Rollback());
    }

    public void Dispose()
    {
        _transaction?.Dispose();
        _connection.Dispose();
    }
}