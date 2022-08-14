using AutoMapper;
using MediatR;
using MeetUp.Logic.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MeetUp.Logic.Events.Queries.Get
{
    public class GetEventDetailsQueryHandler : IRequestHandler<GetEventDetailsQuery, EventDetails>
    {
        private readonly IEventDbContext dbContext;
        private readonly IMapper mapper;

        public GetEventDetailsQueryHandler(IEventDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<EventDetails> Handle(GetEventDetailsQuery request, CancellationToken cancellationToken)
        {
            var eventDt = await dbContext.Events.FirstOrDefaultAsync(eventt => eventt.Id == request.Id, cancellationToken);

            if (eventDt == null)
            {
                throw new Exception();
            }

            return mapper.Map<EventDetails>(eventDt);
        }
    }
}
