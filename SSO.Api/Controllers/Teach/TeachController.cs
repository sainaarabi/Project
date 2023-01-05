using MediatR;
using Microsoft.AspNetCore.Mvc; 
using SSO.Application.Teach.Command;
using SSO.Application.Teach.Queries;
using SSO.Application.Teacher.Command;
using SSO.Application.Teacher.Queries;
using SSO.Core.Domain.Course;
using courses = SSO.Core.Domain.Course.Course;
namespace SSO.Api.Controllers.Teach
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TeachController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateTeachApiModel request)
        {
            var result = await _mediator.Send(new CreateTeachCommand(
               teacherID: request.TeacherID,
                unitID: request.UnitID 
                 ));
            return Ok(result.ApiResult);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> _TeachList([FromQuery] GetTeachApiModel request,
         CancellationToken token)
        {
            var result = await _mediator.Send(new GetTeachQuery(page: request.Page, count: request.Count), token);
            return Ok(result.ApiResult);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> FindTeach(int id,
      CancellationToken token)
        {
            var result = await _mediator.Send(new GetTeachByIdQuery(id), token);
            return StatusCode(result.StatusCode, result.Data);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Delete(int id, CancellationToken token)
        {
            var result = await _mediator.Send(new DeleteTeachCommand(id), token);
            return Ok(result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Edit(int id, EditTeachApiModel request, CancellationToken token)
        {

            var result = await _mediator.Send(new EditTeachCommand(id, request.TeacherID,
                  request.UnitID), token);
            return Ok(result.ApiResult);
        }

        [HttpGet("ClassTiming")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> FindClassTime([FromQuery] GetClassTimeApiModel request,
        CancellationToken token)
        {
            var result = await _mediator.Send(new GetClassTimingQuery(request.TeacherId, request.CourseId), token);
            return StatusCode(result.StatusCode, result.Data);
        }

    }
}
