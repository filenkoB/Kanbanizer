using backend.Domain.Dto;
using backend.Infrastructure.Dapper;
using backend.Service.Interfaces.Repository.Read;
using Dapper;
using System.Data;
using System.Text;

namespace backend.Service.Repository.Read
{
    public class BoardReadRepository : IBoardReadRepository
    {
        private readonly IDbConnection _db;
        public BoardReadRepository(IDBConnector connector) {
            _db = connector.Db;
        }

        #region Methods : Private

        private StringBuilder GetColumnsSqlTextPart(StringBuilder sqlSb, string[] columns) { 
            foreach (var column in columns.SkipLast(1)) {
                sqlSb.Append($"[b].[{column}],");
            }
            return sqlSb.Append($" [b].[{columns.Last()}] ");
        }

        private string GetUserBoardsSqlText(Guid ownerId, string[] columns) {
            StringBuilder sqlSb = new StringBuilder("SELECT");
            return GetColumnsSqlTextPart(sqlSb, columns)
                .Append($"FROM [Board] [b] WHERE [b].[OwnerId] = '{ownerId.ToString()}' ORDER BY [b].[Name]")
                .ToString();
        }

        private string GetSharedBoardsSqlText(Guid userId, string[] columns) {
            StringBuilder sqlSb = new StringBuilder("SELECT");
            return GetColumnsSqlTextPart(sqlSb, columns)
                .Append($"FROM [Board] [b] WHERE EXISTS( " +
                    $"SELECT 1 FROM [Participant] [p] WHERE [b].[Id] = [p].[BoardId] " +
                        $"AND [p].[UserId] = '{userId.ToString()}') " +
                    "ORDER BY [b].[Name]")
                .ToString();
        }

        private async Task<IEnumerable<BaseBoardDto>> GetBoardsAsync(
            Guid userSearchId, Func<Guid, string[], string> getSqlTextFunc
        ) {
            string[] columns = typeof(BaseBoardDto).GetProperties().Select(pi => pi.Name).ToArray();
            string sql = getSqlTextFunc.Invoke(userSearchId, columns);

            var result = new List<BaseBoardDto>();
            using (IDataReader dataReader = await _db.ExecuteReaderAsync(sql)) {
                result.AddRange(dataReader.Parse<BaseBoardDto>());
            }
            return result;
        }

        #endregion

        public async Task<IEnumerable<BaseBoardDto>> GetUserBoardsAsync(Guid ownerId) {
            return await GetBoardsAsync(ownerId, GetUserBoardsSqlText);
        }

        public async Task<IEnumerable<BaseBoardDto>> GetSharedBoardsAsync(Guid userId) { 
            return await GetBoardsAsync(userId, GetSharedBoardsSqlText);
        }

        public async Task<BoardDto> GetBoardInfoAsync(Guid boardId) {
            StringBuilder sqlSb = new StringBuilder();
            sqlSb.AppendLine("SELECT");
            sqlSb.AppendLine("[Id],");
            sqlSb.AppendLine("[Name],");
            sqlSb.AppendLine("[Description],");
            sqlSb.AppendLine("[OwnerId]");
            sqlSb.AppendLine($"FROM [Board] WHERE [Id] = '{boardId}'");

            using (IDataReader dataReader = await _db.ExecuteReaderAsync(sqlSb.ToString())) {
                return dataReader.Parse<BoardDto>().FirstOrDefault();
            }
        }
    }
}
