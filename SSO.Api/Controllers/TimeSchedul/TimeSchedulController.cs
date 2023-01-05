using MediatR;
using Microsoft.AspNetCore.Mvc; 
using SSO.Application.Course.Command;
using SSO.Application.Course.Queries;
using SSO.Application.Teacher.Command;
using SSO.Application.Teacher.Queries;
using SSO.Application.TimeSchedul.Command;
using SSO.Application.TimeSchedul.Queries;

namespace SSO.Api.Controllers.TimeSchedul
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeSchedulController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TimeSchedulController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateTimeSchedul(CreateTimeSchedulApiModel request)
        {
            var result = await _mediator.Send(new CreateTimeSchedulCommand(
                 startTime: request.StartTime,
                 endTime: request.EndTime ,
                 day: request.Day
                 ));
            return Ok(result.ApiResult);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> _TimeSchedulList([FromQuery] GetTimeSchedulApiModel request,
         CancellationToken token)
        {
            var result = await _mediator.Send(new GetTimeSchedulQuery(page: request.Page, count: request.Count), token);
            return Ok(result.ApiResult);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> FindTimeSchedul(int id,
      CancellationToken token)
        {
            var result = await _mediator.Send(new GetTimeSchedulByIdQuery(id), token);
            return StatusCode(result.StatusCode, result.Data);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Delete(int id, CancellationToken token)
        {
            var result = await _mediator.Send(new DeleteTimeSchedulCommand(id), token);
            return Ok(result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Edit(int id, EditTimeSchedulApiModel request, CancellationToken token)
        {

            var result = await _mediator.Send(new EditTimeSchedulCommand(id, 
                   request.StartTime,
                   request.EndTime,
                    request.Day), token);
            return Ok(result.ApiResult);
        }

    }
}
