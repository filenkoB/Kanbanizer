using backend.Domain.Dto;

namespace backend.Service.Interfaces.Repository.Read
{
    public interface IBoardReadRepository
    {
        public Task<IEnumerable<BaseBoardDto>> GetUserBoardsAsync(Guid ownerId);
        public Task<IEnumerable<BaseBoardDto>> GetSharedBoardsAsync(Guid userId);
        public Task<BoardDto> GetBoardInfoAsync(Guid boardId);
    }
}
