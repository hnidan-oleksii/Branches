using Branches_DAL.Entities;

namespace Branches_DAL.Repositories.Interfaces;

public interface IBranchRepository : IRepository<Branch>
{
    Task<IEnumerable<Branch>> GetBranchesWithModeratorsAsync();
    Task<Branch> GetBranchWithMembersAsync(int branchId);
}