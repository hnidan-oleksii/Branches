using Branches_BLL.DTOs.Branch;
using Branches_BLL.DTOs.BranchMember;

namespace Branches_BLL.Services.Interfaces;

public interface IBranchService
{
    Task<IEnumerable<BranchDTO>> GetAllBranchesAsync();
    Task<BranchDTO> GetBranchByIdAsync(int id);
    Task<IEnumerable<BranchMemberDTO>> GetModeratorsByBranchIdAsync(int branchId);
    Task<IEnumerable<BranchMemberDTO>> GetMembersByBranchIdAsync(int branchId);
    Task<int> AddBranchAsync(CreateBranchDTO branchDto);
    Task<int> UpdateBranchAsync(int branchId, CreateBranchDTO branchDto);
    Task<int> DeleteBranchAsync(int branchId);
}