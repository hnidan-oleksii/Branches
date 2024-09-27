using AutoMapper;
using Branches_BLL.DTOs.Branch;
using Branches_BLL.DTOs.BranchMember;
using Branches_BLL.Services.Interfaces;
using Branches_DAL.Entities;
using Branches_DAL.UoW.Interfaces;

namespace Branches_BLL.Services;

public class BranchService : IBranchService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BranchService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BranchDTO>> GetAllBranchesAsync()
        {
            var branches = await _unitOfWork.Branches.GetAllAsync();
            return _mapper.Map<IEnumerable<BranchDTO>>(branches);
        }

        public async Task<BranchDTO> GetBranchByIdAsync(int id)
        {
            var branch = await _unitOfWork.Branches.GetByIdAsync(id);
            return _mapper.Map<BranchDTO>(branch);
        }

        public async Task<IEnumerable<BranchMemberDTO>> GetModeratorsByBranchIdAsync(int branchId)
        {
            var moderators = await _unitOfWork.BranchMembers.GetModeratorsByBranchIdAsync(branchId);
            return _mapper.Map<IEnumerable<BranchMemberDTO>>(moderators);
        }

        public async Task<IEnumerable<BranchMemberDTO>> GetMembersByBranchIdAsync(int branchId)
        {
            var members = await _unitOfWork.BranchMembers.GetMembersByBranchIdAsync(branchId);
            return _mapper.Map<IEnumerable<BranchMemberDTO>>(members);
        }

        public async Task<int> AddBranchAsync(CreateBranchDTO branchDto)
        {
            var branch = _mapper.Map<Branch>(branchDto);
            var newId = await _unitOfWork.Branches.AddAsync(branch);
            await _unitOfWork.CommitAsync();
            return newId;
        }

        public async Task<int> UpdateBranchAsync(int branchId, CreateBranchDTO branchDto)
        {
            var existingBranch = await _unitOfWork.Branches.GetByIdAsync(branchId);
            if (existingBranch == null)
            {
                throw new KeyNotFoundException("Branch not found");
            }

            _mapper.Map(branchDto, existingBranch);
            existingBranch.UpdatedAt = DateTime.UtcNow;

            var updatedId = await _unitOfWork.Branches.UpdateAsync(existingBranch);
            await _unitOfWork.CommitAsync();
            return updatedId;
        }

        public async Task<int> DeleteBranchAsync(int branchId)
        {
            var branch = await _unitOfWork.Branches.GetByIdAsync(branchId);
            if (branch == null)
            {
                throw new KeyNotFoundException("Branch not found");
            }

            var deletedInt = await _unitOfWork.Branches.DeleteAsync(branchId);
            await _unitOfWork.CommitAsync();
            return deletedInt;
        }
    }