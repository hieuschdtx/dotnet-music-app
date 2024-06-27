using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Music_app.Infrastructure.Configurations
{
    public class AuthValidation
    {
        private readonly AuthOption _authOption;
        private SymmetricSecurityKey? _securityKey;

        public AuthValidation(IOptions<AuthOption> authOption)
        {
            _authOption = authOption.Value;
        }

        public int ExpireTime { get; set; } = 2;

        public SymmetricSecurityKey SecurityKey =>
            _securityKey ??= new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authOption.SecretKey));

        public SigningCredentials GetSigning()
        {
            return new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);
        }

        public EncryptingCredentials GetEncrypting()
        {
            return new EncryptingCredentials(SecurityKey, JwtConstants.DirectKeyUseAlg,
                SecurityAlgorithms.Aes128CbcHmacSha256);
        }
    }
}