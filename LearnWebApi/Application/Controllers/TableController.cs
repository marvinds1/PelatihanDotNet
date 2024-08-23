using Core.Features.Queries.CreateTableSpecification;
using Core.Features.Queries.CreateTableSpecificationRedis;
using Core.Features.Queries.GetAllTableSpecifications;
using Core.Features.Queries.GetAllTableSpecificationsRedis;
using Core.Features.Queries.GetTableSpecifications;
using Core.Features.Queries.GetTableSpecificationsRedis;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
                TSpecificationId = id
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

        [HttpGet("v1/table/specification")]
        public async Task<IActionResult> GetAllTableSpecifications([FromQuery] GetAllTableSpecificationsQuery request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("v1/table/specification/redis/{id}")]
        public async Task<GetTableSpecificationsRedisResponse> GetTableSpecificationsRedis(Guid id)
        {
            var request = new GetTableSpecificationsRedisQuery()
            {
                TableSpecificationId = id
            };
            var response = await _mediator.Send(request);
            return response;
        }

        [HttpPost("v1/table/specification/redis")]
        public async Task<IActionResult> CreateTableSpecificationRedis(CreateTableSpecificationRedisQuery request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("v1/table/specification/redis")]
        public async Task<IActionResult> GetAllTableSpecificationsRedis([FromQuery] GetAllTableSpecificationsRedisQuery request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
