using AutoMapper;
using WallsDomain.Entities;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using WallsApplication.Common.Interfaces;

namespace WallsApplication.WallPosts.Commands.CreateWallPost;

public class CreateWallPostCommandHandler(
    IWallContext context,
    IMapper mapper,
    IMemoryCache cache)
    : IRequestHandler<CreateWallPostCommand, int>
{
    public async Task<int> Handle(CreateWallPostCommand request, CancellationToken cancellationToken)
    {
        var author = await context.Users.FindAsync(request.AuthorUserId);
        var profileUser = await context.Users.FindAsync(request.ProfileUserId);

        if (author == null || profileUser == null)
            throw new KeyNotFoundException("Invalid user ID");

        var wallPost = mapper.Map<WallPost>(request);
        context.WallPosts.Add(wallPost);
        await context.SaveChangesAsync(cancellationToken);

        var cacheKey = $"wallPostsByUserId:{request.ProfileUserId}";
        cache.Remove(cacheKey);

        return wallPost.Id;
    }
}