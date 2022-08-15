using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
