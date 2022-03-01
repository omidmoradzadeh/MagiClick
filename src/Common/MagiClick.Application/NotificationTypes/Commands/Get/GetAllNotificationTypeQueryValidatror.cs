using FluentValidation;

namespace MagiClick.Application.NotificationTypes.Commands.Get
{
    public class GetAllNotificationTypeQueryValidatror : AbstractValidator<GetAllNotificationTypeQuery>
    {
        public GetAllNotificationTypeQueryValidatror()
        {
            //RuleFor(x => x.)
            //    .NotNull()
            //    .NotEmpty().WithMessage("DistrictId is required.");

            //RuleFor(x => x.PageNumber)
            //    .GreaterThanOrEqualTo(1).WithMessage("PageNumber at least greater than or equal to 1.");

            //RuleFor(x => x.PageSize)
            //    .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");
        }
    }
}
