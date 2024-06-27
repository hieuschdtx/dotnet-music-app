using System.Security.Claims;

namespace Music_app.Domain.Consts
{
    public class ClaimTypeConst
    {
        public const string Id = "id";
        public const string UserName = "user_name";
        public const string Email = "email";
        public const string Phone = "phone_number";
        public const string RoleName = ClaimTypes.Role;
        public const string RefreshToken = "refresh_token";
    }
}