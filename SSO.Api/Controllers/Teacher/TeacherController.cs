using MediatR;
using Microsoft.AspNetCore.Mvc; 
using SSO.Application.Teacher.Command;
using SSO.Application.Teacher.Queries;

namespace SSO.Api.Controllers.Teacher
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TeacherController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateTeacherApiModel request)
        {
            var result = await _mediator.Send(new CreateTeacherCommand(
               firstName : request.FirstName,
                lastName: request.LastName 
                 ));
            return Ok(result.ApiResult);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> _TeacherList([FromQuery] GetTeacherApiModel request,
         CancellationToken token)
        {
            var result = await _mediator.Send(new GetTeacherQuery(page: request.Page, count: request.Count), token);
            return Ok(result.ApiResult);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> FindTeacher(int id,
      CancellationToken token)
        {
            var result = await _mediator.Send(new GetTeacherByIdQuery(id), token);
            return StatusCode(result.StatusCode, result.Data);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Delete(int id, CancellationToken token)
        {
            var result = await _mediator.Send(new DeleteTeacherCommand(id), token);
            return Ok(result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Edit(int id, EditTeacherApiModel request, CancellationToken token)
        {

            var result = await _mediator.Send(new EditTeacherCommand(id, request.FirstName,
                  request.LastName), token);
            return Ok(result.ApiResult);
        }

    }
}
