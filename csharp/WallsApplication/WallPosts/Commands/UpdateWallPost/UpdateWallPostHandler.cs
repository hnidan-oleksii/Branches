using MediatR;
using Microsoft.Extensions.Caching.Memory;
using WallsApplication.Common.Interfaces;

namespace WallsApplication.WallPosts.Commands.UpdateWallPost;

public class UpdateWallPostCommandHandler(IWallContext context, IMemoryCache cache)
    : IRequestHandler<UpdateWallPostCommand, Unit>
{
    public async Task<Unit> Handle(UpdateWallPostCommand request, CancellationToken cancellationToken)
    {
        var wallPost = await context.WallPosts.FindAsync(request.Id);

        if (wallPost == null)
            throw new KeyNotFoundException($"Wall post with id {request.Id} was not found");

        wallPost.UpdateContent(request.Content);
        await context.SaveChangesAsync(cancellationToken);

        var cacheKey = $"wallPostsByUserId:{wallPost.ProfileUserId}";
        cache.Remove(cacheKey);

        return Unit.Value;
    }
}