using AutoMapper;
using GrpcAggregator.Grpc.Protos.Posts;
using GrpcAggregator.Models;

namespace GrpcAggregator.Mapping;

public class PostsMappingProfile : Profile
{
    public PostsMappingProfile()
    {
        CreateMap<PostResponse, PostModel>();
        CreateMap<PostVote, PostVoteModel>();
    }
}