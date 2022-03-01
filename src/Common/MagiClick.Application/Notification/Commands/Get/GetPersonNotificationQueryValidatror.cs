using FluentValidation;

namespace MagiClick.Application.Notification.Commands.Get
{
    public class PostPersonNotificationQueryValidatror : AbstractValidator<GetPersonNotificationQuery>
    {
        public PostPersonNotificationQueryValidatror()
        {
            RuleFor(x => x.TCKN)
                .NotNull().WithMessage("TCKN is required.")
                .NotEmpty().WithMessage("TCKN is required.");

        }
    }
}
