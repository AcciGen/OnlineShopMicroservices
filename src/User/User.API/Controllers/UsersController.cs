using MediatR;
using Microsoft.AspNetCore.Mvc;
using User.Application.UseCases.UserCases.Commands;
using User.Application.UseCases.UserCases.Queries;
using User.Domain.Entities;

namespace User.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<UserInfo>>> GetAll()
        {
            var result = await _mediator.Send(new GetAllUsersQuery());

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteUserCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateUserCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
