using FluentValidation;

namespace MagiClick.Application.Notification.Commands.Post
{
    public class PostPersonNotificationQueryValidatror : AbstractValidator<PostPersonNotificationQuery>
    {
        public PostPersonNotificationQueryValidatror()
        {
            RuleFor(x => x.PersonId)
                .NotNull().WithMessage("Person Id is required")
                .NotEmpty().WithMessage("Person Id is required")
                .GreaterThan(0).WithMessage("Person Id must grater than 0 and exist");

            RuleFor(x => x.NotificationTypeId)
                .NotNull().WithMessage("Notification Type Id is required")
                .NotEmpty().WithMessage("Notification Type Id is required")
                .GreaterThan(0).WithMessage("Notification type id must grater than 0 and exist");
        }
    }
}
