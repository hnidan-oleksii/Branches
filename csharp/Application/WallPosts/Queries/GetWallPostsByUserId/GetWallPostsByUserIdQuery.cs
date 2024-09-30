using Application.Common.Models;
using MediatR;

namespace Application.WallPosts.Queries.GetWallPostsByUserId;

public class GetWallPostsByUserIdQuery : IRequest<List<WallPostDto>>
{
    public int UserId { get; }
    
    public GetWallPostsByUserIdQuery(int userId)
    {
        UserId = userId;
    }    
}
