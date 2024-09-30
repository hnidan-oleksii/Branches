using Domain.Entities;
using Application.Common.Models;
using Application.WallComments.Commands.CreateWallComment;
using AutoMapper;

namespace Application.Common.Mappings;

public class WallCommentMappingProfile : Profile
{
    public WallCommentMappingProfile()
    {
        CreateMap<WallComment, WallCommentDto>();
        CreateMap<CreateWallCommentCommand, WallCommentDto>();
    }
}