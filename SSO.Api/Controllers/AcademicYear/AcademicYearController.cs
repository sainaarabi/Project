using MediatR;
using Microsoft.AspNetCore.Mvc;
using SSO.Api.CustomAttribute;
using SSO.Application.AcademicYear.Command;
using SSO.Application.AcademicYear.Queries; 

namespace SSO.Api.Controllers.AcademicYear
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcademicYearController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AcademicYearController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost] 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateAcademicYearApiModel request)
        {
            var result = await _mediator.Send(new CreateAcademicYearCommand(
                date: request.Date
                 ));
            return Ok(result.ApiResult);
        }

        [HttpGet] 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> _AcademicYearList([FromQuery] GetAcademicYearApiModel request,
          CancellationToken token)
        {
            var result = await _mediator.Send(new GetAcademicYearQuery(page: request.Page, count: request.Count), token);
            return Ok(result.ApiResult);
        }

        [HttpGet("{id}")] 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> FindAAcademicYear(int id,
      CancellationToken token)
        {
            var result = await _mediator.Send(new GetAcademicYearByIdQuery(id), token);
            return StatusCode(result.StatusCode, result.Data);
        }

        [HttpDelete("{id}")] 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Delete(int id, CancellationToken token)
        {
            var result = await _mediator.Send(new DeleteAcademicYearCommand(id), token);
            return Ok(result);
        }

        [HttpPut("{id}")] 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Edit(int id, EditAcademicYearApiModel request, CancellationToken token)
        {

            var result = await _mediator.Send(new EditAcademicYearCommand(id, request.Date), token);
            return Ok(result.ApiResult);
        }
        


    }

}
