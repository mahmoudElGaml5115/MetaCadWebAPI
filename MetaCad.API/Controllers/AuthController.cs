using MediatR;
using MetaCad.Application.Features.AppUser.Commands;
using MetaCad.Application.Models.Auth;
using Microsoft.AspNetCore.Mvc;

namespace MetaCad.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var result = await _mediator.Send(new RegisterCommand { Model = model });
            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
