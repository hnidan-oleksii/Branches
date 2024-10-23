using AutoMapper;
using PostsBLL.DTOs.PostVote;
using PostsDAL_EF.Entities;

namespace PostsBLL.AutomapperProfiles;

public class PostVoteMappingProfile : Profile
{
    public PostVoteMappingProfile()
    {
        CreateMap<PostVote, PostVoteDTO>();
        CreateMap<CreatePostVoteDTO, PostVote>();
    }
}