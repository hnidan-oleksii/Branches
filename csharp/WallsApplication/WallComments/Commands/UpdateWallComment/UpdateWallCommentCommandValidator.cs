using FluentValidation;

namespace WallsApplication.WallComments.Commands.UpdateWallComment;

public class UpdateWallCommentCommandValidator : AbstractValidator<UpdateWallCommentCommand>
{
    public UpdateWallCommentCommandValidator()
    {
        RuleFor(x => x.Content)
            .NotEmpty().WithMessage("New content is required")
            .MaximumLength(500).WithMessage("Content cannot exceed 500 characters");
        Console.WriteLine(1);
    }
}
