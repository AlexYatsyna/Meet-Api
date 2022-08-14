using MediatR;

namespace MeetUp.Logic.Events.Commands.Create
{
    public class CreateEventCommand : IRequest<Guid>
    {
        public string Title { get; set; }
        public string Topic { get; set; }
        public string Description { get; set; }
        public string Plan { get; set; }
        public DateTime TimeEvent { get; set; }
        public string Location { get; set; }
        public string Organizers { get; set; }
        public string Speakers { get; set; }
    }
}
