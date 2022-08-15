using FluentValidation;

namespace MeetUp.Logic.Events.Commands.Delete
{
    public class DeleteEventCommandValidator : AbstractValidator<DeleteEventCommand>
    {
        public DeleteEventCommandValidator()
        {
            RuleFor(deleteEventCommand => deleteEventCommand.Id).NotEmpty().NotEqual(Guid.Empty);
            RuleFor(deleteEventCommand => deleteEventCommand.AuthorID).NotEmpty().NotEqual(Guid.Empty);
        }
    }
}
