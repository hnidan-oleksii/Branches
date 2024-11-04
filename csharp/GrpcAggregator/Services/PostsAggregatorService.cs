using AutoMapper;
using Grpc.Core;
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
        var commentResponseStream = commentClient.GetCommentsByPostId(commentRequest);

        var comments = new List<CommentModel>();
        await foreach (var comment in commentResponseStream.ResponseStream.ReadAllAsync())
            comments.Add(mapper.Map<CommentModel>(comment));

        var aggregatedPost = new PostModel
        {
            Id = postResponse.Post.Id,
            Title = postResponse.Post.Title,
            Content = postResponse.Post.Content,
            UserId = postResponse.Post.UserId,
            Votes = mapper.Map<List<PostVoteModel>>(postResponse.Post.Votes),
            Comments = comments
        };

        return aggregatedPost;
    }
}