using AutoMapper;
using Branches_BLL.DTOs.Branch;
using Branches_DAL.Entities;

namespace Branches_BLL.AutomapperProfiles;

public class BranchMappingProfile : Profile
{
    public BranchMappingProfile()
    {
        CreateMap<Branch, BranchDTO>().ReverseMap();
        CreateMap<CreateBranchDTO, Branch>().ReverseMap();
    }
}