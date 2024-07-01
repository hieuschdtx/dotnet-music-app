using System.Net;
using System.Reflection;
using Music_app.Domain.Commons.Commands;
using Music_app.Domain.Enums;
using Music_app.Domain.Exceptions;
using Music_app.Domain.Extensions;
using Music_app.Domain.Interfaces;
using Music_app.Domain.Models;

namespace Music_app.Application.Commands.Roles.Update
{
    public class UpdateRoleCommandHandler : ICommandHandler<UpdateRoleCommand, ResponseBase>
    {
        private readonly IRoleRepository _roleRepository;

        public UpdateRoleCommandHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<ResponseBase> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            var currentRole = await _roleRepository.GetByIdAsync(request.id);
            if (currentRole == null)
            {
                throw new BusinessRuleException("Role", "Quyền người dùng không tồn tại!", HttpStatusCode.NotFound);
            }

            if (request.name != null)
            {
                var isRoleName = EnumExtension.IsValidEnum<RoleTypeEnum>(request.name);

                if (!isRoleName)
                {
                    throw new BusinessRuleException("Role", "Quyền người dùng không hợp lệ!", HttpStatusCode.BadRequest);
                }
            }

            var type = typeof(UpdateRoleCommand);

            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                 .Where(p => p.CanRead && p.CanWrite);

            foreach (var property in properties)
            {
                var value = property.GetValue(request);
                if (value != null)
                {
                    var propertyName = property.Name;
                    var roleProperty = currentRole.GetType()
                    .GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

                    if (roleProperty != null && roleProperty.CanWrite)
                    {
                        if (propertyName == "name")
                        {
                            var enumValue = EnumExtension.ParseEnum<RoleTypeEnum>(value.ToString()!);
                            roleProperty.SetValue(currentRole, enumValue);
                        }
                        else
                        {
                            roleProperty.SetValue(currentRole, value);
                        }
                    }
                }
            }

            await _roleRepository.UpdateAsync(currentRole);
            await _roleRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            return new ResponseBase("success", "Cập nhật role thành công!");
        }
    }
}