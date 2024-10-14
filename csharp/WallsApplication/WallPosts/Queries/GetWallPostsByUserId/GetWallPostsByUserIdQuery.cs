using MediatR;
using WallsApplication.Common.Models;

namespace WallsApplication.WallPosts.Queries.GetWallPostsByUserId;

public class GetWallPostsByUserIdQuery : IRequest<List<WallPostDto>>
{
    public int UserId { get; }
    
    public GetWallPostsByUserIdQuery(int userId)
    {
        UserId = userId;
    }    
}
