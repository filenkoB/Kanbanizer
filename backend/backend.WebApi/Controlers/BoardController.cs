using backend.Domain.Dto;
using backend.Service.Extensions;
using backend.Service.Handlers;
using backend.Service.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.WebApi.Controlers
{
    [Authorize]
    public class BoardController : BaseApiController
    {
        private readonly IAuthService _authService;
        public BoardController(IMediator mediator, IAuthService authService) : base(mediator) {
            _authService = authService;
        }

        [HttpGet("userBoards")]
        public async Task<IActionResult> GetUserBoards() {
            Guid userId = _authService.ReadJwtTokenEntityData<UserDto>(this.ReadJwnToken()).Id;
            var result = await CallRequestHandler<IEnumerable<BaseBoardDto>>(typeof(GetUserBoardsRequest), userId);
            return Ok(result);
        }

        [HttpGet("shared")]
        public async Task<IActionResult> GetSharedBoards() {
            Guid userId = _authService.ReadJwtTokenEntityData<UserDto>(this.ReadJwnToken()).Id;
            var result = await CallRequestHandler<IEnumerable<BaseBoardDto>>(typeof(GetSharedBoardsRequest), userId);
            return Ok(result);
        }

        [HttpGet("{boardId}")]
        public async Task<IActionResult> GetBoardInfo(Guid boardId) { 
            return Ok(await CallRequestHandler<BoardDto>(typeof(GetBoardInfoRequest), boardId));
        }
    }
}
