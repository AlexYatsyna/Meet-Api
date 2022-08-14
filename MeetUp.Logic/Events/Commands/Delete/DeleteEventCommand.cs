using MediatR;

namespace MeetUp.Logic.Events.Commands.Delete
{
    public class DeleteEventCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
