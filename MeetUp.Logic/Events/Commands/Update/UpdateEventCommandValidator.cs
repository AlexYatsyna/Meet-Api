using FluentValidation;

namespace MeetUp.Logic.Events.Commands.Update
{
    public class UpdateEventCommandValidator : AbstractValidator<UpdateEventCommand>
    {
        public UpdateEventCommandValidator()
        {
            RuleFor(updateEventCommand => updateEventCommand.Id).NotEmpty().NotEqual(Guid.Empty);
            RuleFor(updateEventCommand => updateEventCommand.AuthorId).NotEmpty().NotEqual(Guid.Empty);
            RuleFor(updateEventCommand => updateEventCommand.Title).NotEmpty().MaximumLength(25);
            RuleFor(updateEventCommand => updateEventCommand.Topic).NotEmpty().MaximumLength(30);
            RuleFor(updateEventCommand => updateEventCommand.Description).NotEmpty().MaximumLength(255);
            RuleFor(updateEventCommand => updateEventCommand.Plan).NotEmpty().MaximumLength(255);
            RuleFor(updateEventCommand => updateEventCommand.Location).NotEmpty().MaximumLength(50);
            RuleFor(updateEventCommand => updateEventCommand.TimeEvent).NotEmpty();
            RuleFor(updateEventCommand => updateEventCommand.Speakers).NotEmpty().MaximumLength(255);
            RuleFor(updateEventCommand => updateEventCommand.Organizers).NotEmpty().MaximumLength(255);

        }
    }
}
