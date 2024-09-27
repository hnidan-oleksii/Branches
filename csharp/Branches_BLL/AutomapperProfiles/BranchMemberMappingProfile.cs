using AutoMapper;
using Branches_BLL.DTOs.BranchMember;
using Branches_DAL.Entities;

namespace Branches_BLL.AutomapperProfiles;

public class BranchMemberMappingProfile : Profile
{
    public BranchMemberMappingProfile()
    {
        CreateMap<BranchMember, BranchMemberDTO>().ReverseMap();
    }
}