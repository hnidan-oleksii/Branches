using WallsDomain.Entities;
using AutoMapper;
using WallsApplication.Common.Models;
using WallsApplication.WallComments.Commands.CreateWallComment;

namespace WallsApplication.Common.Mappings;

public class WallCommentMappingProfile : Profile
{
    public WallCommentMappingProfile()
    {
        CreateMap<WallComment, WallCommentDto>();
        CreateMap<CreateWallCommentCommand, WallComment>();
    }
}