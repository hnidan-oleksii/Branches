using FluentValidation;
using PostsBLL.DTOs.Post;

namespace PostsBLL.Validation.Posts;

public class CreatePostDtoValidator : AbstractValidator<CreatePostDTO>
{
    public CreatePostDtoValidator()
    {
        RuleFor(p => p.Title).NotEmpty().WithMessage("Title is required").MaximumLength(255)
            .WithMessage("Title must not exceed 255 characters");
        RuleFor(x => x.Content).NotEmpty().WithMessage("Content is required");
    }
}