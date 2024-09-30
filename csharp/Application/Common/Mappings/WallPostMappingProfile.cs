using Application.Common.Models;
using Application.WallPosts.Commands.CreateWallPost;
using AutoMapper;
using Domain.Entities;

namespace Application.Common.Mappings;

public class WallPostMappingProfile : Profile
{
    public WallPostMappingProfile()
    {
        CreateMap<WallPost, WallPostDto>();
        CreateMap<CreateWallPostCommand, WallPost>();
    }
}