using FluentValidation;
using PostsBLL.DTOs.PostVote;

namespace PostsBLL.Validation.PostVotes;

public class CreatePostVoteDtoValidator : AbstractValidator<CreatePostVoteDTO>
{
    public CreatePostVoteDtoValidator()
    {
        RuleFor(x => x.PostId).NotEmpty().WithMessage("Post ID cannot be empty");
        RuleFor(x => x.VoteType).Must(x => new[] { -1, 1 }.Contains(x))
            .WithMessage("Vote Type must be one of the following: -1, 1");
    }
}