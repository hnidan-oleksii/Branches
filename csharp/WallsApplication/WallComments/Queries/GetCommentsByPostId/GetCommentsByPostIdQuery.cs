using MediatR;
using WallsApplication.Common.Models;

namespace WallsApplication.WallComments.Queries.GetCommentsByPostId;

public record GetCommentsByPostIdQuery : IRequest<List<WallCommentDto>>
{
    public int PostId { get; }

    public GetCommentsByPostIdQuery(int postId)
    {
        PostId = postId;
    }
}