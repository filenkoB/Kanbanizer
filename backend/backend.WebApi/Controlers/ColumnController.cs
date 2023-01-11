using backend.Domain.Dto;
using backend.Service.Handlers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.WebApi.Controlers
{
    [Authorize]
    public class ColumnController : BaseApiController
    {
        public ColumnController(IMediator mediator) : base(mediator) { }

        [HttpGet("{boardId}")]
        public async Task<IActionResult> GetBoardColumns(Guid boardId) {
            var columns = await CallRequestHandler<IEnumerable<ColumnDto>>(typeof(GetBoardColumnsRequest), boardId);
            return Ok(columns);
        }
    }
}
