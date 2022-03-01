using FluentValidation;

namespace MagiClick.Application.People.Commands.Post
{

    public class PostPersonQueryValidator : AbstractValidator<PostPersonQuery>
    {
        public PostPersonQueryValidator()
        {
            RuleFor(x => x.TCKN)
                .NotNull()
                .NotEmpty().WithMessage("TCKN is required.");

            RuleFor(x => x.Name)
                .MinimumLength(3).WithMessage("Minimum Length of name is 3 character.")
                .MaximumLength(50).WithMessage("Maximum Length of name is 50 character.");

        }
    }
}
