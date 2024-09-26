using MediatR;
using Microsoft.AspNetCore.Mvc;
using Security.Application.Commands;
using Security.Application.Queries;

namespace Security.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        #region Properties

        private readonly IMediator _mediator;
        private readonly ILogger<UserController> _logger;

        #endregion

        #region Constructors

        public UserController(ILogger<UserController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        #endregion

        #region Queries

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _mediator.Send(new GetUserByIdQuery(id));
            return user.Id != 0 ? Ok(user) : NotFound();
            return Ok();
        }

        #endregion

        #region Persistênce

        [HttpPost("create")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command)
        {
            var userId = await _mediator.Send(command);
            return CreatedAtAction("CreateUser", new { id = userId }, userId);
        }

        #endregion
    }

}
