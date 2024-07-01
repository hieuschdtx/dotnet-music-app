using Dapper;
using Music_app.Domain.Commons;
using Music_app.Domain.Models;

namespace Music_app.Application.Services.RoleServices
{
    public class RoleService : IRoleService
    {
        private readonly ISqlConnectionFactory _factory;

        public RoleService(ISqlConnectionFactory factory)
        {
            _factory = factory;
        }

        public async Task<IEnumerable<RoleDto>> GetAllCategoryAsync()
        {
            const string query = "select * from roles order by created_at asc";
            using var conn = _factory.GetOpenConnection();
            return await conn.QueryAsync<RoleDto>(query);
        }
    }
}