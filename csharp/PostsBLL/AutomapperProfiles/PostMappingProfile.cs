using AutoMapper;
using PostsBLL.DTOs.Post;
using PostsDAL_EF.Entities;

namespace PostsBLL.AutomapperProfiles;

public class PostMappingProfile : Profile
{
    public PostMappingProfile()
    {
        CreateMap<Post, PostDTO>().ReverseMap();
        CreateMap<CreatePostDTO, Post>();
    }
}