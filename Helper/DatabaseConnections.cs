using System.Data;
namespace NetCore8ApiDapper.Helper
{
    public class DatabaseConnections
    {
        public IDbConnection DefaultConnection { get; }
        public IDbConnection SecondConnection { get; }
        public DatabaseConnections(IDbConnection defaultConnection, IDbConnection secondConnection)
        {
            DefaultConnection = defaultConnection;
            SecondConnection = secondConnection;
        }
    }
}
