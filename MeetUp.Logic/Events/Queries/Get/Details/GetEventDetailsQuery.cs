using MediatR;

namespace MeetUp.Logic.Events.Queries.Get
{
    public class GetEventDetailsQuery : IRequest<EventDetails>
    {
        public Guid Id { get; set; }
    }
}
