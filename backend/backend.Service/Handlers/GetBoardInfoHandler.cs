using backend.Domain.Dto;
using backend.Service.Interfaces.Repository.Read;
using MediatR;

namespace backend.Service.Handlers
{
    public class GetBoardInfoRequest : IRequest<BoardDto>
    {
        public Guid BoardId { get; set; }

        public GetBoardInfoRequest(Guid boardId) {
            BoardId = boardId;
        }   
    }

    public class GetBoardInfoHandler : IRequestHandler<GetBoardInfoRequest, BoardDto>
    {
        private readonly IBoardReadRepository _boardReadRepository;

        public GetBoardInfoHandler(IBoardReadRepository boardReadRepository) {
            _boardReadRepository = boardReadRepository;
        }

        public async Task<BoardDto> Handle(GetBoardInfoRequest request, CancellationToken token) { 
            return await _boardReadRepository.GetBoardInfoAsync(request.BoardId);
        }
    }
}
