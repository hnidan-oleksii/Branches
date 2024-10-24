using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using WallsApplication.Common.Interfaces;
using WallsApplication.Common.Models;

namespace WallsApplication.WallPosts.Queries.GetWallPostsByUserId;

public class GetWallPostsByUserIdQueryHandler(
    IWallContext context,
    IMapper mapper,
    IMemoryCache cache)
    : IRequestHandler<GetWallPostsByUserIdQuery, List<WallPostDto>>
{
    public async Task<List<WallPostDto>> Handle(GetWallPostsByUserIdQuery request, CancellationToken cancellationToken)
    {
        var user = await context.Users.FindAsync(request.UserId);
        if (user == null)
        {
            throw new KeyNotFoundException($"User with id {request.UserId} not found");
        }

        var cacheKey = $"wallPostsByUserId:{request.UserId}";

        if (cache.TryGetValue(cacheKey, out List<WallPostDto>? posts)) return posts;

        var postsEntities = await context.WallPosts
            .Where(p => p.ProfileUserId == request.UserId)
            .ToListAsync(cancellationToken);
        posts = mapper.Map<List<WallPostDto>>(postsEntities);
        var cacheOptions = new MemoryCacheEntryOptions()
            .SetSlidingExpiration(TimeSpan.FromSeconds(30))
            .SetAbsoluteExpiration(TimeSpan.FromMinutes(5))
            .SetPriority(CacheItemPriority.Normal)
            .SetSize(2048);
        cache.Set(cacheKey, posts, cacheOptions);

        return posts;
    }
}