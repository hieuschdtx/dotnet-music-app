using FluentValidation;

namespace Music_app.Application.Commands.Roles.AddRole;

public class AddRoleCommandValidator : AbstractValidator<AddRoleCommand>
{
    public AddRoleCommandValidator()
    {
        #region Generated Constructor

        RuleFor(p => p.name).NotEmpty().WithMessage("Tên không được để trống.");
        ;
        RuleFor(p => p.name).MaximumLength(255).WithMessage("Tên không quá 256 kí tự.");
        RuleFor(p => p.name).MinimumLength(1).WithMessage("Tên phải trên 1 kí tự.");
        RuleFor(p => p.description).MaximumLength(255).WithMessage("Mô tả không quá 256 kí tự.");

        #endregion
    }
}