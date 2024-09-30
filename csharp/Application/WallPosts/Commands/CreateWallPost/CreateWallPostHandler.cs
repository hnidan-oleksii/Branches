using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.WallPosts.Commands.CreateWallPost;

public class CreateWallPostCommandHandler : IRequestHandler<CreateWallPostCommand, int>
{
    private readonly IWallContext _context;
    private readonly IMapper _mapper;

    public CreateWallPostCommandHandler(IWallContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateWallPostCommand request, CancellationToken cancellationToken)
    {
        var author = await _context.Users.FindAsync(request.AuthorUserId);
        var profileUser = await _context.Users.FindAsync(request.ProfileUserId);

        if (author == null || profileUser == null)
            throw new KeyNotFoundException("Invalid user ID");

        var wallPost = _mapper.Map<WallPost>(request);
        _context.WallPosts.Add(wallPost);
        await _context.SaveChangesAsync(cancellationToken);

        return wallPost.Id;
    }
}

