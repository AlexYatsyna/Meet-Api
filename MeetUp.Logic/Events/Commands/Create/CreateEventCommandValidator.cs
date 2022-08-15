using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetUp.Logic.Events.Commands.Create
{
    public class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
    {
        public CreateEventCommandValidator()
        {
            RuleFor(createEventCommand => createEventCommand.AuthorId).NotEmpty().NotEqual(Guid.Empty);
            RuleFor(createEventCommand => createEventCommand.Title).NotEmpty().MaximumLength(25);
            RuleFor(createEventCommand => createEventCommand.Topic).NotEmpty().MaximumLength(30);
            RuleFor(createEventCommand => createEventCommand.Description).NotEmpty().MaximumLength(255);
            RuleFor(createEventCommand => createEventCommand.Plan).NotEmpty().MaximumLength(255);
            RuleFor(createEventCommand => createEventCommand.Location).NotEmpty().MaximumLength(50);
            RuleFor(createEventCommand => createEventCommand.TimeEvent).NotEmpty();
            RuleFor(createEventCommand => createEventCommand.Speakers).NotEmpty().MaximumLength(255);
            RuleFor(createEventCommand => createEventCommand.Organizers).NotEmpty().MaximumLength(255);
        }
    }
}