using Music_app.Domain.Models;

namespace Music_app.Application.Services.RoleServices
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleDto>> GetAllCategoryAsync();
    }
}