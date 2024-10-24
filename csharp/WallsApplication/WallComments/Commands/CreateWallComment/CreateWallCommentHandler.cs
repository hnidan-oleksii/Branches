using AutoMapper;
using WallsDomain.Entities;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using WallsApplication.Common.Interfaces;

namespace WallsApplication.WallComments.Commands.CreateWallComment;

public class CreateWallCommentCommandHandler(
    IWallContext context,
    IMapper mapper,
    IMemoryCache cache)
    : IRequestHandler<CreateWallCommentCommand, int>
{
    public async Task<int> Handle(CreateWallCommentCommand request, CancellationToken cancellationToken)
    {
        var wallPost = await context.WallPosts.FindAsync(request.PostId);

        if (wallPost == null)
            throw new KeyNotFoundException("Wall post not found");

        var wallComment = mapper.Map<WallComment>(request);
        context.WallComments.Add(wallComment);
        await context.SaveChangesAsync(cancellationToken);

        var cacheKey = $"wallCommentsByPostId:{request.PostId}";
        cache.Remove(cacheKey);

        return wallComment.Id;
    }
}