using backend.Domain.Dto;
using backend.Service.Interfaces.Repository.Read;
using MediatR;

namespace backend.Service.Handlers
{
    public class GetBoardColumnsRequest : IRequest<IEnumerable<ColumnDto>>
    {
        public Guid BoardId { get; set; }

        public GetBoardColumnsRequest(Guid boardId) {
            BoardId = boardId;
        }   
    }

    public class GetBoardColumnsHandler : IRequestHandler<GetBoardColumnsRequest, IEnumerable<ColumnDto>> {
        private IColumnsReadRepository _columnsReadRepository;

        public GetBoardColumnsHandler(IColumnsReadRepository columnsReadRepository) {
            _columnsReadRepository = columnsReadRepository;
        }

        public async Task<IEnumerable<ColumnDto>> Handle(GetBoardColumnsRequest request, CancellationToken _) {
            return await _columnsReadRepository.ReadBoardColumns(request.BoardId);
        }
    }
}
