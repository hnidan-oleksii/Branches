using AutoMapper;
using WallsDomain.Entities;
using WallsApplication.Common.Models;
using WallsApplication.WallPosts.Commands.CreateWallPost;

namespace WallsApplication.Common.Mappings;

public class WallPostMappingProfile : Profile
{
    public WallPostMappingProfile()
    {
        CreateMap<WallPost, WallPostDto>();
        CreateMap<CreateWallPostCommand, WallPost>();
    }
}