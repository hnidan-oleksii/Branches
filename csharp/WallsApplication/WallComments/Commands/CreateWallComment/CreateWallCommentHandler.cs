using AutoMapper;
using WallsDomain.Entities;
using MediatR;
using WallsApplication.Common.Interfaces;

namespace WallsApplication.WallComments.Commands.CreateWallComment;

public class CreateWallCommentCommandHandler : IRequestHandler<CreateWallCommentCommand, int>
{
    private readonly IWallContext _context;
    private readonly IMapper _mapper;

    public CreateWallCommentCommandHandler(IWallContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateWallCommentCommand request, CancellationToken cancellationToken)
    {
        var wallPost = await _context.WallPosts.FindAsync(request.PostId);

        if (wallPost == null)
            throw new KeyNotFoundException("Wall post not found");

        var wallComment = _mapper.Map<WallComment>(request);
        _context.WallComments.Add(wallComment);
        await _context.SaveChangesAsync(cancellationToken);

        return wallComment.Id;
    }
}
