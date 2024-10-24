using AutoMapper;
using Branches_BLL.DTOs.Branch;
using Branches_BLL.DTOs.BranchMember;
using Branches_BLL.Services.Interfaces;
using Branches_DAL.Entities;
using Branches_DAL.UoW.Interfaces;
using Branches.Extensions;
using Microsoft.Extensions.Caching.Distributed;

namespace Branches_BLL.Services;

public class BranchService(IUnitOfWork unitOfWork, IMapper mapper, IDistributedCache cache) : IBranchService
{
    public async Task<IEnumerable<BranchDTO>> GetAllBranchesAsync()
    {
        const string cacheKey = "branches";
        if (cache.TryGetValue(cacheKey, out IEnumerable<BranchDTO>? branches)) return branches!;

        var branchesEntities = await unitOfWork.Branches.GetAllAsync();
        branches = mapper.Map<IEnumerable<BranchDTO>>(branchesEntities);
        await cache.SetAsync(cacheKey, branches);
        return branches;
    }

    public async Task<BranchDTO> GetBranchByIdAsync(int id)
    {
        var cacheKey = $"branch:{id}";
        if (cache.TryGetValue(cacheKey, out BranchDTO? branch)) return branch!;

        var branchesEntities = await unitOfWork.Branches.GetByIdAsync(id);
        branch = mapper.Map<BranchDTO>(branchesEntities);
        await cache.SetAsync(cacheKey, branch);
        return branch;
    }

    public async Task<IEnumerable<BranchMemberDTO>> GetModeratorsByBranchIdAsync(int branchId)
    {
        var cacheKey = $"branchModeratorsByBranchId:{branchId}";
        if (cache.TryGetValue(cacheKey, out IEnumerable<BranchMemberDTO>? moderators)) return moderators!;

        var moderatorsEntities = await unitOfWork.BranchMembers.GetModeratorsByBranchIdAsync(branchId);
        moderators = mapper.Map<IEnumerable<BranchMemberDTO>>(moderatorsEntities);
        await cache.SetAsync(cacheKey, moderators);

        return moderators;
    }

    public async Task<IEnumerable<BranchMemberDTO>> GetMembersByBranchIdAsync(int branchId)
    {
        var cacheKey = $"branchMembersByBranchId:{branchId}";
        if (cache.TryGetValue(cacheKey, out IEnumerable<BranchMemberDTO>? members)) return members!;

        var membersEntities = await unitOfWork.BranchMembers.GetMembersByBranchIdAsync(branchId);
        members = mapper.Map<IEnumerable<BranchMemberDTO>>(membersEntities);
        await cache.SetAsync(cacheKey, members);

        return members;
    }

    public async Task<int> AddBranchAsync(CreateBranchDTO branchDto)
    {
        var branch = mapper.Map<Branch>(branchDto);
        var newId = await unitOfWork.Branches.AddAsync(branch);
        await unitOfWork.CommitAsync();

        const string cacheKey = "branches";
        await cache.RemoveAsync(cacheKey);

        return newId;
    }

    public async Task<int> UpdateBranchAsync(int branchId, CreateBranchDTO branchDto)
    {
        var existingBranch = await unitOfWork.Branches.GetByIdAsync(branchId);
        if (existingBranch == null)
        {
            throw new KeyNotFoundException("Branch not found");
        }

        mapper.Map(branchDto, existingBranch);
        existingBranch.UpdatedAt = DateTime.UtcNow;

        var updatedId = await unitOfWork.Branches.UpdateAsync(existingBranch);
        await unitOfWork.CommitAsync();

        const string cacheKeyGeneral = "branches";
        var cacheKeyId = $"branches:{branchId}";
        await cache.RemoveAsync(cacheKeyGeneral);
        await cache.RemoveAsync(cacheKeyId);

        return updatedId;
    }

    public async Task<int> DeleteBranchAsync(int branchId)
    {
        var branch = await unitOfWork.Branches.GetByIdAsync(branchId);
        if (branch == null)
        {
            throw new KeyNotFoundException("Branch not found");
        }

        var deletedInt = await unitOfWork.Branches.DeleteAsync(branchId);
        await unitOfWork.CommitAsync();

        const string cacheKeyGeneral = "branches";
        var cacheKeyId = $"branches:{branchId}";
        await cache.RemoveAsync(cacheKeyGeneral);
        await cache.RemoveAsync(cacheKeyId);

        return deletedInt;
    }
}