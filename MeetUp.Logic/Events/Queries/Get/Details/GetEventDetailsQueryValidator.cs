using FluentValidation;

namespace MeetUp.Logic.Events.Queries.Get.Details
{
    public class GetEventDetailsQueryValidator : AbstractValidator<GetEventDetailsQuery>
    {
        public GetEventDetailsQueryValidator()
        {
            RuleFor(query => query.Id).NotEmpty().NotEqual(Guid.Empty);
        }
    }
}
