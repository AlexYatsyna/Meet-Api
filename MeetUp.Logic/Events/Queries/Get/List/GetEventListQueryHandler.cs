using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using MeetUp.Logic.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MeetUp.Logic.Events.Queries.Get.List
{
    internal class GetEventListQueryHandler : IRequestHandler<GetEventListQuery, EventList>
    {

        private readonly IEventDbContext dbContext;
        private readonly IMapper mapper;

        public GetEventListQueryHandler(IEventDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<EventList> Handle(GetEventListQuery request, CancellationToken cancellationToken)
        {
            List<EventListDetails> events;

            if (request.AuthorId != Guid.Empty)
                events = await dbContext.Events.Where(ev => ev.AuthorId == request.AuthorId)
                                 .ProjectTo<EventListDetails>(mapper.ConfigurationProvider)
                                 .ToListAsync(cancellationToken);
            else
                events = await dbContext.Events.AsQueryable().ProjectTo<EventListDetails>(mapper.ConfigurationProvider)
                                 .ToListAsync(cancellationToken);
            

            return new EventList { Events = events };
        }
    }
}
