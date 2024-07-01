using Music_app.Application.Services.RoleServices;
using Music_app.Domain.Commons.Queries;
using Music_app.Domain.Models;

namespace Music_app.Application.Queries.Roles.GetAllRole
{
    public class GetAllRoleQueryHandler : IQueryHandler<GetAllRoleQuery, IEnumerable<RoleDto>>
    {
        private readonly IRoleService _roleService;
        public GetAllRoleQueryHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<IEnumerable<RoleDto>> Handle(GetAllRoleQuery request, CancellationToken cancellationToken)
        {
            return await _roleService.GetAllCategoryAsync();
        }
    }
}