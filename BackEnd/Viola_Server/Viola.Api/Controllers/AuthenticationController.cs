using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Viola.Application.DTOs;
using Viola.Application.Features.Authentication.Commands;
using Viola.Application.Interface;

namespace Viola.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

        private readonly IMediator _mediator;
        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterCommand registerCommand)
        {
            try
            {
                await _mediator.Send(registerCommand);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand loginCommand)
        {
            try
            {
                var token = await _mediator.Send(loginCommand);
                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
