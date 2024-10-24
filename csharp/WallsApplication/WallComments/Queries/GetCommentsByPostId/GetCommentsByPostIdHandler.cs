using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using WallsApplication.Common.Interfaces;
using WallsApplication.Common.Models;

namespace WallsApplication.WallComments.Queries.GetCommentsByPostId;

public class GetCommentsByPostIdQueryHandler(
    IWallContext context,
    IMapper mapper,
    IMemoryCache cache)
    : IRequestHandler<GetCommentsByPostIdQuery, List<WallCommentDto>>
{
    public async Task<List<WallCommentDto>> Handle(GetCommentsByPostIdQuery request,
        CancellationToken cancellationToken)
    {
        var post = await context.WallPosts.FindAsync(request.PostId);
        if (post == null)
        {
            throw new KeyNotFoundException($"Post {request.PostId} not found");
        }

        var cacheKey = $"wallCommentsByPostId:{request.PostId}";

        if (cache.TryGetValue(cacheKey, out List<WallCommentDto>? comments)) return comments;

        var commentsEntities = await context.WallComments
            .Where(c => c.PostId == request.PostId)
            .ToListAsync(cancellationToken);
        comments = mapper.Map<List<WallCommentDto>>(commentsEntities);
        var cacheOptions = new MemoryCacheEntryOptions()
            .SetSlidingExpiration(TimeSpan.FromSeconds(30))
            .SetAbsoluteExpiration(TimeSpan.FromMinutes(5))
            .SetPriority(CacheItemPriority.Normal)
            .SetSize(2048);
        cache.Set(cacheKey, comments, cacheOptions);

        return comments;
    }
}