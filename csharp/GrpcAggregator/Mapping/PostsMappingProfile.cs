using AutoMapper;
using GrpcAggregator.Grpc.Protos.Posts;
using GrpcAggregator.Models;

namespace GrpcAggregator.Mapping;

public class PostsMappingProfile : Profile
{
    public PostsMappingProfile()
    {
        CreateMap<Post, PostModel>();
        CreateMap<PostVote, PostVoteModel>();
    }
}