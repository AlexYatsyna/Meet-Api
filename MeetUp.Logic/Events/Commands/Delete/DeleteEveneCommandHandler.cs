using MediatR;
using MeetUp.Logic.Interfaces;

namespace MeetUp.Logic.Events.Commands.Delete
{
    public class DeleteEveneCommandHandler : IRequestHandler<DeleteEventCommand>
    {
        private readonly IEventDbContext dbContext;

        public DeleteEveneCommandHandler(IEventDbContext dbContext) => this.dbContext = dbContext;

        public async Task<Unit> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            var eventD = await dbContext.Events.FindAsync(new object[] { request.Id }, cancellationToken);

            if (eventD == null)
            {
                throw new Exception();
            }

            dbContext.Events.Remove(eventD);
            await dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
