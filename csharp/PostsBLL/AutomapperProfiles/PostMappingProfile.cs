using AutoMapper;
using PostsBLL.DTOs.Post;
using PostsDAL_ADO.Entities;

namespace PostsBLL.AutomapperProfiles;

public class PostMappingProfile : Profile
{
    public PostMappingProfile()
    {
        CreateMap<Post, PostDTO>();
        CreateMap<CreatePostDTO, Post>();
    }
}