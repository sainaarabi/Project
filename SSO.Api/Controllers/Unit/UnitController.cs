using MediatR;
using Microsoft.AspNetCore.Mvc; 
using SSO.Application.Course.Command;
using SSO.Application.Course.Queries;
using SSO.Application.Teacher.Command;
using SSO.Application.Teacher.Queries;
using SSO.Application.Unit.Command;
using SSO.Application.Unit.Queries;

namespace SSO.Api.Controllers.Unit
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UnitController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateUnit(CreateUnitApiModel request)
        {
            var result = await _mediator.Send(new CreateUnitCommand(
                 courseID: request.CourseID,
                 academicYearID: request.AcademicYearID ,
                 timeScheduleID: request.TimeScheduleID
                 ));
            return Ok(result.ApiResult);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> _UnitList([FromQuery] GetUnitApiModel request,
         CancellationToken token)
        {
            var result = await _mediator.Send(new GetUnitQuery(page: request.Page, count: request.Count), token);
            return Ok(result.ApiResult);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> FindUnit(int id,
      CancellationToken token)
        {
            var result = await _mediator.Send(new GetUnitByIdQuery(id), token);
            return StatusCode(result.StatusCode, result.Data);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Delete(int id, CancellationToken token)
        {
            var result = await _mediator.Send(new DeleteUnitCommand(id), token);
            return Ok(result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Edit(int id, EditUnitApiModel request, CancellationToken token)
        {

            var result = await _mediator.Send(new EditUnitCommand(id,  request.CourseID,
                   request.AcademicYearID,
                   request.TimeScheduleID), token);
            return Ok(result.ApiResult);
        }

    }
}
