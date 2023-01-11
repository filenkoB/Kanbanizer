using MediatR;
using backend.Domain.Dto;
using backend.Service.Interfaces.Repository.Read;

namespace backend.Service.Handlers
{
    public class GetSharedBoardsRequest : IRequest<IEnumerable<BaseBoardDto>>
    {
        public Guid UserId { get; set; }
        public GetSharedBoardsRequest(Guid userId) {
            UserId = userId;
        }
    }

    public class GetSharedBoardsHandler : IRequestHandler<GetSharedBoardsRequest, IEnumerable<BaseBoardDto>>
    {
        private readonly IBoardReadRepository _boardReadRepository;
        public GetSharedBoardsHandler(IBoardReadRepository boardReadRepository) {
            _boardReadRepository = boardReadRepository;
        }
        public async Task<IEnumerable<BaseBoardDto>> Handle(GetSharedBoardsRequest request, CancellationToken token) {
            return await _boardReadRepository.GetSharedBoardsAsync(request.UserId);
        }
    }
}
