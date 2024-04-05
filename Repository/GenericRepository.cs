using Dapper.Contrib.Extensions;
using NetCore8ApiDapper.Helper;
using NetCore8ApiDapper.Interfaces;
using System.Data;

namespace NetCore8ApiDapper.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        private readonly IDbConnection _connection;
        private readonly IConfiguration _configuration;

        public GenericRepository(DatabaseConnections connections, IConfiguration configuration)
        {
            _connection = connections.DefaultConnection;
            _configuration = configuration;
        }

        public async Task<int> AddAsync(T entity)
        {
            return await _connection.InsertAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entityToDelete = await _connection.GetAsync<T>(id);
            if (entityToDelete != null)
            {
                return await _connection.DeleteAsync(entityToDelete);
            }
            return false;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _connection.GetAllAsync<T>();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _connection.GetAsync<T>(id);
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            return await _connection.UpdateAsync(entity);
        }
    }

}
