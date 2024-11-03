using AutoMapper;
using GrpcAggregator.Grpc.Protos.Comments;
using GrpcAggregator.Grpc.Protos.Posts;
using GrpcAggregator.Models;

namespace GrpcAggregator.Services;

public class PostsAggregatorService(
    CommentService.CommentServiceClient commentClient,
    PostService.PostServiceClient postClient,
    IMapper mapper)
{
    public async Task<PostModel> GetAggregatedPostAsync(int postId)
    {
        var postRequest = new PostRequest { PostId = postId };
        var postResponse = await postClient.GetPostWithVotesAsync(postRequest);

        var commentRequest = new CommentsRequest { PostId = postId };
        var commentResponse = await commentClient.GetCommentsByPostIdAsync(commentRequest);

        var aggregatedPost = new PostModel
        {
            Id = postResponse.Post.Id,
            Title = postResponse.Post.Title,
            Content = postResponse.Post.Content,
            UserId = postResponse.Post.UserId,
            Votes = mapper.Map<List<PostVoteModel>>(postResponse.Post.Votes),
            Comments = mapper.Map<List<CommentModel>>(commentResponse.Comments)
        };

        return aggregatedPost;
    }
}