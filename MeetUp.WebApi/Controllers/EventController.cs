using AutoMapper;
using MediatR;
using MeetUp.Logic.Events.Commands.Create;
using MeetUp.Logic.Events.Commands.Delete;
using MeetUp.Logic.Events.Commands.Update;
using MeetUp.Logic.Events.Queries.Get;
using MeetUp.Logic.Events.Queries.Get.List;
using MeetUp.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
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

        /// <summary>
        /// Gets all of the events
        /// </summary>
        /// <remarks>
        /// Example: GET /event 
        /// 
        /// If User Guid is Empty return all events
        /// else onlu events,which created this user
        /// </remarks>
        /// <returns>Returns list of events</returns>
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

        /// <summary>
        /// Gets event by  id
        /// </summary>
        /// <remarks>
        /// Example: GET /event/11111111-1111-1111-1111-11111111
        /// </remarks>
        /// <param name="id">Event id(guid)</param>
        /// <returns>Event details</returns>
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

        /// <summary>
        /// Create event
        /// </summary>
        /// <remarks>
        /// Example: POST /event<br /> 
        /// {<br /> 
        ///     Title : "asd",<br /> 
        ///     Topic : "asd",<br /> 
        ///     Description : "asd",<br /> 
        ///     Plan : "asd",<br /> 
        ///     TimeEvent : 2022-07-01 15:30,<br /> 
        ///     Location : "asd",<br /> 
        ///     Organizers : "asd, asd",<br /> 
        ///     Speakers : "asdasd , asd a,as d"<br /> 
        /// }
        /// </remarks>
        /// <param name="createEventModel">Event model object</param>
        /// <returns>Event id</returns>
        [HttpPost]
        //[Authorize]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateEventModel createEventModel)
        {
            var command = mapper.Map<CreateEventCommand>(createEventModel);
            command.AuthorId = UserId;
            var eventId = await Mediator.Send(command);
            return Ok(eventId);
        }

        /// <summary>
        /// Update event
        /// </summary>
        /// <remarks>
        ///  Example: POST /event <br />
        /// {<br />
        ///     Title : "asd",<br />
        ///     Topic : "asd",<br />
        ///     Description : "asd",<br />
        ///     Plan : "asd",<br />
        ///     TimeEvent : 2022-07-01 15:30,<br />
        ///     Location : "asd",<br />
        ///     Organizers : "asd, asd",<br />
        ///     Speakers : "asdasd , asd a,as d"<br />
        /// }
        /// </remarks>
        /// <param name="updateEventModel">Update event object</param>
        /// <returns>NoContent</returns>
        [HttpPut]
        //[Authorize]
        public async Task<IActionResult> Update([FromBody] UpdateEventModel updateEventModel)
        {
            var command = mapper.Map<UpdateEventCommand>(updateEventModel);
            command.AuthorId = UserId;
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Delete event by id
        /// </summary>
        /// <param name="id">Event id(guid)</param>
        /// <returns>NoContent</returns>
        [HttpDelete("{id}")]
        //[Authorize]
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
