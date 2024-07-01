using System.Net;
using Music_app.Domain.Commons.Commands;
using Music_app.Domain.Enums;
using Music_app.Domain.Exceptions;
using Music_app.Domain.Extensions;
using Music_app.Domain.Interfaces;
using Music_app.Domain.Models;

namespace Music_app.Application.Commands.Roles.Add
{
    public class AddRoleCommandHandler : ICommandHandler<AddRoleCommand, ResponseBase>
    {
        private readonly IRoleRepository _roleRepository;

        public AddRoleCommandHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<ResponseBase> Handle(AddRoleCommand request, CancellationToken cancellationToken)
        {
            var isRoleName = EnumExtension.IsValidEnum<RoleTypeEnum>(request.name);

            if (!isRoleName)
            {
                throw new BusinessRuleException("Role", "Quyền người dùng không hợp lệ!", HttpStatusCode.BadRequest);
            }

            var roleName = EnumExtension.ParseEnum<RoleTypeEnum>(request.name);

            var newRole = new Domain.Entities.Roles(
                request.id,
                roleName,
                request.description,
                request.disable);

            await _roleRepository.AddAsync(newRole);
            await _roleRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            return new ResponseBase("success", "Thêm quyền người dùng thành công!");
        }
    }
}