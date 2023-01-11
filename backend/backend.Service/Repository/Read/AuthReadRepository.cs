using backend.DBEngine;
using backend.Domain.Model;
using backend.Infrastructure.Dapper;
using backend.Service.Interfaces.Repository.Read;
using Dapper;
using System.Data;

namespace backend.Service.Repository.Read
{
    public class AuthReadRepository : IAuthReadRepository
    {
        private readonly IDbConnection _db;
        public AuthReadRepository(IDBConnector connector) {
            _db = connector.Db;
        }

        public async Task<User?> ReadUserByCredentials(string login, string password) {
            var sqlCommand = "SELECT [Id], [Name], [Surname], [RegisteredOn] " +
                "FROM [User] [u] WHERE EXISTS (" +
                    $"SELECT 1 FROM [Credential] [c] WHERE [c].[Login] = '{login}'" +
                        $"AND [c].[PasswordHash] = '{password}' AND [c].[UserId] = [u].[Id])";

            using (IDataReader dataReader = await _db.ExecuteReaderAsync(sqlCommand)) {
                if (!dataReader.Read()) {
                    return null;
                }
                return new User() {
                    Id = dataReader.GetGuid(0),
                    Name = dataReader.GetString(1),
                    Surname = dataReader.GetString(2),
                    RegisteredOn = dataReader.GetDateTime(3)
                };
            }
        }
    }
}
