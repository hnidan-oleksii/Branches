using FluentValidation;
using PostsBLL.DTOs.Post;

namespace PostsBLL.Validation.Posts;

public class UpdatePostDtoValidator : AbstractValidator<UpdatePostDTO>
{
    public UpdatePostDtoValidator()
    {
        RuleFor(p => p.Title).NotEmpty().WithMessage("Title is required").MaximumLength(255)
            .WithMessage("Title must not exceed 255 characters");
        RuleFor(p => p.Content).NotEmpty().WithMessage("Content is required");
    }
}