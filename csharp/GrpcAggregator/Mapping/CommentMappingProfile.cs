using AutoMapper;
using GrpcAggregator.Grpc.Protos.Comments;
using GrpcAggregator.Models;

namespace GrpcAggregator.Mapping;

public class CommentMappingProfile : Profile
{
    public CommentMappingProfile()
    {
        CreateMap<Comment, CommentModel>();
        CreateMap<CommentVote, CommentVoteModel>();
    }
}