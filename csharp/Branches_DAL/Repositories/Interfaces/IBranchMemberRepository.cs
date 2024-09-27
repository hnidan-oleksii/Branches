using Branches_DAL.Entities;

namespace Branches_DAL.Repositories.Interfaces;

public interface IBranchMemberRepository : IRepository<BranchMember>
{
    Task<IEnumerable<BranchMember>> GetMembersByBranchIdAsync(int branchId);
    Task<IEnumerable<BranchMember>> GetModeratorsByBranchIdAsync(int branchId);
}