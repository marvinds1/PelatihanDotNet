using Core.Features.Queries.CreateTableSpecification;
using Core.Features.Queries.UpdateTableSpecification;
using Core.Features.Queries.DeleteTableSpecification;
using Core.Features.Queries.GetTableSpecifications;
using MediatR;
using Persistence.DatabaseContext;
using Persistence.Models;
using Microsoft.AspNetCore.Mvc;
using Persistence.Repositories;

namespace Application.Controllers
{
    public class TableController : BaseController
    {
        private readonly IMediator _mediator;

        public TableController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("v1/table/specification/{id}")]
        public async Task<GetTableSpecificationsResponse> GetTableSpecifications(Guid id)
        {
            var request = new GetTableSpecificationsQuery()
            {
                TableSpecificationId = id
            };
            var response = await _mediator.Send(request);
            return response;
        }

        [HttpPost("v1/table/specification")]
        public async Task<IActionResult> CreateTableSpecification([FromBody] CreateTableSpecificationQuery request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("v1/table/specification/")]
        public async Task<IActionResult> GetAllTableSpecifications([FromQuery] GetAllTableSpecificationsQuery request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        //[HttpPut("v1/table/specification/{id}")]
        //public async Task<IActionResult> UpdateTableSpecification(Guid id, [FromBody] UpdateTableSpecificationCommand command)
        //{
        //    if (command == null || command.TableSpecificationId != id)
        //    {
        //        return BadRequest("Invalid request");
        //    }

        //    var response = await _mediator.Send(command);

        //    if (response.IsSuccess)
        //    {
        //        return NoContent();
        //    }
        //    else
        //    {
        //        return BadRequest(response.Errors);
        //    }
        //}

        //[HttpDelete("v1/table/specification/{id}")]
        //public async Task<IActionResult> DeleteTableSpecification(Guid id)
        //{
        //    var command = new DeleteTableSpecificationCommand
        //    {
        //        TableSpecificationId = id
        //    };

        //    var response = await _mediator.Send(command);

        //    if (response.IsSuccess)
        //    {
        //        return NoContent();
        //    }
        //    else
        //    {
        //        return NotFound(response.Errors);
        //    }
        //}
    }
}
