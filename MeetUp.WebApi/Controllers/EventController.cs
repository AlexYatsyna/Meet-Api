using AutoMapper;
using MediatR;
using MeetUp.Logic.Events.Commands.Create;
using MeetUp.Logic.Events.Commands.Delete;
using MeetUp.Logic.Events.Commands.Update;
using MeetUp.Logic.Events.Queries.Get;
using MeetUp.Logic.Events.Queries.Get.List;
using MeetUp.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MeetUp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : Controller
    {

        private readonly IMapper mapper;
        protected IMediator Mediator => HttpContext.RequestServices.GetService<IMediator>();

        internal Guid UserId => !User.Identity.IsAuthenticated
            ? Guid.Empty
            : Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
        public EventController(IMapper mapper) => this.mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<EventList>> GetAll()
        {
            var query = new GetEventListQuery
            {
                AuthorId = UserId
            };
            var list = await Mediator.Send(query);
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventDetails>> GetByID(Guid id)
        {
            var query = new GetEventDetailsQuery
            {
                Id = id
            };
            var eventDetail = await Mediator.Send(query);
            return Ok(eventDetail);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateEventModel createEventModel)
        {
            var command = mapper.Map<CreateEventCommand>(createEventModel);
            command.AuthorId = UserId;
            var eventId = await Mediator.Send(command);
            return Ok(eventId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateEventModel updateEventModel)
        {
            var command = mapper.Map<UpdateEventCommand>(updateEventModel);
            command.AuthorId = UserId;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteEventCommand
            {
                Id = id,
                AuthorID = UserId
            };

            await Mediator.Send(command);
            return NoContent();
        }
    }
}
