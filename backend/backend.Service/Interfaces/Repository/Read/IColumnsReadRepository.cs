using backend.Domain.Dto;

namespace backend.Service.Interfaces.Repository.Read
{
    public interface IColumnsReadRepository
    {
        public Task<IEnumerable<ColumnDto>> ReadBoardColumns(Guid boardId);
    }
}
