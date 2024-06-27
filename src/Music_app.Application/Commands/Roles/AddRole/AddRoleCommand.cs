using Music_app.Domain.Commons.Commands;
using Music_app.Domain.Models;

namespace Music_app.Application.Commands.Roles.AddRole
{
    public class AddRoleCommand : CommandBase<ResponseBase>
    {
        public string name { get; set; }
        public string description { get; set; }
        public bool disable { get; set; } = false;
    }
}