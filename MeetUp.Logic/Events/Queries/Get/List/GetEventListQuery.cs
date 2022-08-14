using MediatR;

namespace MeetUp.Logic.Events.Queries.Get.List
{
    public class GetEventListQuery : IRequest<EventList>
    {
        public Guid AuthorId { get; set; }
    }
}
