using FluentValidation;

namespace Music_app.Application.Commands.Roles.Update
{
    public class UpdateRoleCommandValidator : AbstractValidator<UpdateRoleCommand>
    {
        public UpdateRoleCommandValidator()
        {
            RuleFor(p => p.name).MaximumLength(255).WithMessage("Tên không quá 256 kí tự.");
            RuleFor(p => p.description).MaximumLength(255).WithMessage("Mô tả không quá 256 kí tự.");
        }
    }
}