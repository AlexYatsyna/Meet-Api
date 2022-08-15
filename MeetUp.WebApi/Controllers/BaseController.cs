using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MeetUp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public abstract class BaseController : ControllerBase
    {
        private IMediator _mediator;
        
    }

}
