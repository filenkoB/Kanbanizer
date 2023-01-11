using backend.Domain.Dto;
using backend.Service.Interfaces.Repository.Read;
using Dapper;
using System.Data;
using System.Reflection.PortableExecutable;
using System.Text;

namespace backend.Service.Repository.Read
{
    public class ColumnsReadRepository : IColumnsReadRepository
    {
        private readonly IDbConnection _db;

        public ColumnsReadRepository(IDbConnection db) {
            _db = db;
        }

        public async Task<IEnumerable<ColumnDto>> ReadBoardColumns(Guid boardId) {
            StringBuilder sqlSb = new StringBuilder();
            sqlSb.AppendLine("SELECT");
            sqlSb.AppendLine("[Id],");
            sqlSb.AppendLine("[Name],");
            sqlSb.AppendLine("[MaxTasks],");
            sqlSb.AppendLine("[Order]");
            sqlSb.AppendLine($"FROM [Column] WHERE [BoardId] = '{boardId}' ORDER BY [Order]");

            var result = new List<ColumnDto>();
            using (IDataReader dataReader = await _db.ExecuteReaderAsync(sqlSb.ToString())) {
                result.AddRange(dataReader.Parse<ColumnDto>());
            }
            return result;
        }
    }
}
