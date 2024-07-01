using Music_app.Domain.Commons.Commands;
using Music_app.Domain.Models;

namespace Music_app.Application.Commands.Users.Add
{
    public class AddUserCommand : CommandBase<ResponseBase>
    {
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int role_id { get; set; }
    }
}