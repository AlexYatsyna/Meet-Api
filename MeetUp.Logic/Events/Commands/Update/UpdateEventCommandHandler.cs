using MediatR;
using MeetUp.Logic.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MeetUp.Logic.Events.Commands.Update
{
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand>
    {
        private readonly IEventDbContext dbContext;

        public UpdateEventCommandHandler(IEventDbContext dbContext) => this.dbContext = dbContext;

        public async Task<Unit> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var eventU = await dbContext.Events.FirstOrDefaultAsync(ev => ev.Id == request.Id, cancellationToken);

            if (eventU == null /*|| eventU.AuthorId != request.AuthorId*/)
            {
                throw new Exception();
            }

            eventU.Title = request.Title;
            eventU.Topic = request.Topic;
            eventU.Description = request.Description;
            eventU.Plan = request.Plan;
            eventU.Location = request.Location;
            eventU.TimeEvent = request.TimeEvent;
            eventU.Organizers = request.Organizers;
            eventU.Speakers = request.Speakers;

            await dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
