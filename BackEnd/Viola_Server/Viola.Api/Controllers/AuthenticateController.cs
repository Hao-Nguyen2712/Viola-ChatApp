using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;
using Viola.Application.Commands;

namespace Viola.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IMediator mediator;
        
        public AuthenticateController(IMediator mediator)
        {
            this.mediator = mediator;           
        }
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterCommand registerCommand)
        {
            var result = await mediator.Send(registerCommand);
            return Ok(result);
        }
    }
}
