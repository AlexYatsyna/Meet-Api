using MediatR;
using MeetUp.Data;
using MeetUp.Logic.Interfaces;

namespace MeetUp.Logic.Events.Commands.Create
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Guid>
    {
        private readonly IEventDbContext dbContext;

        public CreateEventCommandHandler(IEventDbContext dbContext) => this.dbContext = dbContext;

        public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var eventD = new MeetupEventModel
            {
                Id = Guid.NewGuid(),
                AuthorId = request.AuthorId,
                Title = request.Title,
                Topic = request.Topic,
                Description = request.Description,
                Plan = request.Plan,
                TimeEvent = request.TimeEvent,
                Location = request.Location,
                Organizers = request.Organizers,
                Speakers = request.Speakers
            };

            await dbContext.Events.AddAsync(eventD, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);

            return eventD.Id;
        }
    }
}
