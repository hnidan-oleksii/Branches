using FluentValidation;

namespace Application.WallComments.Commands.CreateWallComment;

public class CreateWallCommentCommandValidator : AbstractValidator<CreateWallCommentCommand>
{
    public CreateWallCommentCommandValidator()
    {
        RuleFor(x => x.Content)
            .NotEmpty().WithMessage("Comment content is required")
            .MaximumLength(500).WithMessage("Content cannot exceed 500 characters");

        RuleFor(x => x.PostId)
            .NotEmpty().WithMessage("PostId is required");

        RuleFor(x => x.AuthorUserId)
            .NotEmpty().WithMessage("AuthorUserId is required");
    }
}
