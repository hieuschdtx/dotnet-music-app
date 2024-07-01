using System.Data;
using Microsoft.Extensions.Configuration;
using Music_app.Domain.Commons;
using Npgsql;

namespace Music_app.Infrastructure.Data
{
    public class SqlConnectionFactory : ISqlConnectionFactory, IDisposable
    {
        private readonly IConfiguration _configuration;
        private IDbConnection _connection;

        public SqlConnectionFactory(IDbConnection connection, IConfiguration configuration)
        {
            _connection = connection;
            _configuration = configuration;
        }

        public void Dispose()
        {
            if (_connection is { State: ConnectionState.Open })
                _connection.Dispose();
        }

        public IDbConnection GetOpenConnection()
        {
            if (_connection.State == ConnectionState.Open)
                return _connection;
            _connection = new NpgsqlConnection(_configuration.GetConnectionString("PgConnection"));
            _connection.Open();

            return _connection;
        }
    }
}