using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.AspNetCore.Mvc;
using NetCore8ApiDapper.Helper;
using NetCore8ApiDapper.Interfaces;
using NetCore8ApiDapper.Models;
using System.Data;

namespace NetCore8ApiDapper.Repository
{
    public class NotlarRepository : GenericRepository<Notlar>, INotlarRepository
    {
        private readonly IDbConnection _connection;

        public NotlarRepository(DatabaseConnections connections, IConfiguration configuration) : base(connections, configuration)
        {
            _connection = connections.DefaultConnection; // ilk veri tabanı

        }

        public async Task<IEnumerable<object>> GetAllAsync2()
        {
            var notlar = await _connection.QueryAsync<object>("SELECT *,'selamlar' as naber FROM notlar");
            return notlar;
        }

        public async Task<IEnumerable<Notlar>> GetAllAsync3()
        {
            var notlar = await _connection.QueryAsync<Notlar>("SELECT * FROM notlar");
            return notlar;
        }
    }

}
