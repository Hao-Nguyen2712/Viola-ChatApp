using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Viola.Application.Commands;
using Viola.Application.Queries;
using Viola.Domain.Entities;

namespace Viola.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("GetUser")]
        public async Task<IActionResult> GetUser()
        {
            var result = await _mediator.Send(new GetUserQuerry());
            return Ok(result);
        }

        [HttpGet]
        [Route("GetUserById/{id}", Name = "GetUserById")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var result = await _mediator.Send(new GetUserByIdQuerry(id));
            return Ok(result);
        }

        [HttpPost]
        [Route("AddUser")]
        public async Task<IActionResult> AddUser(AddUserCommand user)
        {
            var result = await _mediator.Send(user);
            return CreatedAtRoute("GetUserById", new { id = user.UserId }, result );
        }
    }
}
