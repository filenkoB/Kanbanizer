using MediatR;
using backend.Domain.Dto;
using backend.Service.Interfaces.Repository.Read;

namespace backend.Service.Handlers
{
    public class GetUserBoardsRequest : IRequest<IEnumerable<BaseBoardDto>>
    {
        public Guid OwnerId { get; set; }
        public GetUserBoardsRequest(Guid ownerId) {
            OwnerId = ownerId;
        }
    }

    public class GetUserBoardsHandler : IRequestHandler<GetUserBoardsRequest, IEnumerable<BaseBoardDto>>
    {
        private readonly IBoardReadRepository _boardReadRepository;
        public GetUserBoardsHandler(IBoardReadRepository boardReadRepository) {
            _boardReadRepository = boardReadRepository;
        }
        public async Task<IEnumerable<BaseBoardDto>> Handle(GetUserBoardsRequest request, CancellationToken token) {
            return await _boardReadRepository.GetUserBoardsAsync(request.OwnerId);
        }
    }
}
