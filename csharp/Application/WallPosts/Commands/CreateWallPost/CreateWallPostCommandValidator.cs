using FluentValidation;

namespace Application.WallPosts.Commands.CreateWallPost;

public class CreateWallPostCommandValidator : AbstractValidator<CreateWallPostCommand>
{
    public CreateWallPostCommandValidator()
    {
        RuleFor(x => x.Content)
            .NotEmpty().WithMessage("Content is required")
            .MaximumLength(1000).WithMessage("Content cannot exceed 1000 characters");

        RuleFor(x => x.AuthorUserId)
            .NotEmpty().WithMessage("AuthorUserId is required");

        RuleFor(x => x.ProfileUserId)
            .NotEmpty().WithMessage("ProfileUserId is required");
    }
}
