using Grpc.Core;
using PostsBLL.Grpc.Protos;
using PostsBLL.Services.Interfaces;

namespace PostsBLL.Grpc;

public class PostsService(IPostService postService) : PostService.PostServiceBase
{
    public override async Task<PostResponse> GetPostWithVotes(PostRequest request, ServerCallContext context)
    {
        var postDTO = await postService.GetPostByIdAsync(request.PostId);
        var postResponse = new PostResponse
        {
            Post = new Post
            {
                Id = postDTO.Id,
                Title = postDTO.Title,
                Content = postDTO.Content,
                UserId = postDTO.UserId,
                Votes = { postDTO.Votes.Select(v => new PostVote { Id = v.Id, UserId = v.UserId, VoteType = v.VoteType }) }
            }
        };
        return postResponse;
    }
}
