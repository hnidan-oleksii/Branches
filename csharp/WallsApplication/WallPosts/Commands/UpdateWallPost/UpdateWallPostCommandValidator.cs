using FluentValidation;

namespace WallsApplication.WallPosts.Commands.UpdateWallPost;

public class UpdateWallPostCommandValidator : AbstractValidator<UpdateWallPostCommand>
{
    public UpdateWallPostCommandValidator()
    {
        RuleFor(x => x.Content)
            .NotEmpty().WithMessage("New content is required")
            .MaximumLength(1000).WithMessage("Content cannot exceed 1000 characters");
        Console.WriteLine(1);
    }
}
