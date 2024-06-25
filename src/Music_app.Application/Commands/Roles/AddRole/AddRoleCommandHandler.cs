using Music_app.Domain.Commons.Commands;
using Music_app.Domain.Interfaces;
using Music_app.Domain.Models;

namespace Music_app.Application.Commands.Roles.AddRole;

public class AddRoleCommandHandler : ICommandHandler<AddRoleCommand, ResponseBase>
{
    private readonly IRoleRepository _roleRepository;

    public AddRoleCommandHandler(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<ResponseBase> Handle(AddRoleCommand request, CancellationToken cancellationToken)
    {
        var newRole = new Domain.Entities.Roles(
            request.id,
            request.name,
            request.description,
            request.disable);

        await _roleRepository.AddAsync(newRole);
        await _roleRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        return new ResponseBase("success", "Add successfully");
    }
}