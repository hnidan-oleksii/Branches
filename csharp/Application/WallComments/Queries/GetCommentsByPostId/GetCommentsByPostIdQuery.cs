using Application.Common.Models;
using MediatR;

namespace Application.WallComments.Queries.GetCommentsByPostId;

public record GetCommentsByPostIdQuery : IRequest<List<WallCommentDto>>
{
    public int PostId { get; }

    public GetCommentsByPostIdQuery(int postId)
    {
        PostId = postId;
    }
}