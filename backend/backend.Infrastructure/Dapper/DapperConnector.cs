using System.Data;

namespace backend.Infrastructure.Dapper
{
    public interface IDBConnector {
        public IDbConnection Db { get; set; }
    }

    public class DapperConnector : IDBConnector
    {
        public IDbConnection Db { get; set; }
        public DapperConnector(IDbConnection connection) {
            Db = connection;
        }
    }
}
