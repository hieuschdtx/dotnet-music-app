using System.Net;
using Music_app.Domain.Commons.Commands;
using Music_app.Domain.Exceptions;
using Music_app.Domain.Interfaces;
using Music_app.Domain.Models;

namespace Music_app.Application.Commands.Roles.Delete
{
    public class DeleteRoleCommandHandler : ICommandHandler<DeleteRoleCommand, ResponseBase>
    {
        private readonly IRoleRepository _roleRepository;

        public DeleteRoleCommandHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<ResponseBase> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            var role = await _roleRepository.GetByIdAsync(request.id);

            if (role == null)
            {
                throw new BusinessRuleException("Role", "Không tồn tại quyền người dùng", HttpStatusCode.NotFound);
            }

            await _roleRepository.DeleteAsync(role);
            await _roleRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            return new ResponseBase("success", "Xóa quyền người dùng thành công");
        }
    }
}