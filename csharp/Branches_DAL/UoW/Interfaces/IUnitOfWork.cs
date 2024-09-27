using Branches_DAL.Repositories.Interfaces;

namespace Branches_DAL.UoW.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IBranchRepository Branches { get; }
    IBranchMemberRepository BranchMembers { get; }
    Task CommitAsync();
    Task RollbackAsync();
}