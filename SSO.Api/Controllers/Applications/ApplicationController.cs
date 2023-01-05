using MediatR;
using Microsoft.AspNetCore.Mvc;
using SSO.Api.CustomAttribute;
using SSO.Application.Applications.Commands;
using SSO.Application.Applications.DTO;
using SSO.Application.Applications.Queries;

namespace SSO.Api.Controllers.Applications
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ApplicationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost] 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateApplicationApiModel request)
        {
            var result = await _mediator.Send(new CreateApplicationCommand(
                title: request.Title,
                code: request.Code,
                link: request.Link
                 ));
            return Ok(result.ApiResult);
        }

        [HttpGet] 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> _ApplicationsList([FromQuery] GetApplicationApiModel request,
          CancellationToken token)
        {
            var result = await _mediator.Send(new GetApplicationQuery(page: request.Page, count: request.Count), token);
            return Ok(result.ApiResult);
        }

        [HttpGet("{id}")] 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> FindApplications(int id,
      CancellationToken token)
        {
            var result = await _mediator.Send(new GetApplicationByIdQuery(id), token);
            return StatusCode(result.StatusCode, result.Data);
        }

        [HttpDelete("{id}")] 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Delete(int id, CancellationToken token)
        {
            var result = await _mediator.Send(new DeleteApplicationCommand(id), token);
            return Ok(result);
        }

        [HttpPut("{id}")] 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Edit(int id, EditApplicationApiModel request, CancellationToken token)
        {

            var result = await _mediator.Send(new EditApplicationCommand(id, request.Title,
                  request.Code, request.Link), token);
            return Ok(result.ApiResult);
        }
        [HttpPost("SearchApp")]
        [ValidateTokenAttribute]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> SearchApp(SearchApplicationDto request, CancellationToken token)
         =>
       Ok((await _mediator.Send(new SearchApplicationCommand(request), token)).ApiResult);


    }

}
