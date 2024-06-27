using Music_app.Domain.Entities;
using Music_app.Domain.Interfaces;
using Music_app.Infrastructure.Data;

namespace Music_app.Infrastructure.Repositories
{
    public class RoleRepository : Repository<Roles>, IRoleRepository
    {
        public RoleRepository(MusicDbContext context) : base(context)
        {
        }
    }
}