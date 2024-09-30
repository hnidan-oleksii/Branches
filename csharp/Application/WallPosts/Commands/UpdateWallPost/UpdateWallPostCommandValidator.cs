using FluentValidation;

namespace Application.WallPosts.Commands.UpdateWallPost;

public class UpdateWallPostCommandValidator : AbstractValidator<UpdateWallPostCommand>
{
    public UpdateWallPostCommandValidator()
    {
        RuleFor(x => x.NewContent)
            .NotEmpty().WithMessage("New content is required")
            .MaximumLength(1000).WithMessage("Content cannot exceed 1000 characters");
    }
}
