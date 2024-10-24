using MediatR;
using Microsoft.Extensions.Caching.Memory;
using WallsApplication.Common.Interfaces;

namespace WallsApplication.WallPosts.Commands.DeleteWallPost;

public class DeleteWallPostCommandHandler(IWallContext context, IMemoryCache cache)
    : IRequestHandler<DeleteWallPostCommand, Unit>
{
    public async Task<Unit> Handle(DeleteWallPostCommand request, CancellationToken cancellationToken)
    {
        var wallPost = await context.WallPosts.FindAsync(request.PostId);

        if (wallPost == null)
            throw new KeyNotFoundException($"Wall post with id {request.PostId} was not found");

        context.WallPosts.Remove(wallPost);
        await context.SaveChangesAsync(cancellationToken);

        var cacheKey = $"wallPostsByUserId:{wallPost.ProfileUserId}";
        cache.Remove(cacheKey);

        return Unit.Value;
    }
}