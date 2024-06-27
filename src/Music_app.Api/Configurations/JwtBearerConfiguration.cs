using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Music_app.Infrastructure.Configurations;

namespace Music_app.Api.Configurations
{
    public class JwtBearerConfiguration : IConfigureOptions<JwtBearerOptions>
    {
        private readonly AuthOption _authOption;
        private readonly AuthValidation _authValidation;

        public JwtBearerConfiguration(IOptions<AuthOption> authOption,AuthValidation authValidation)
        {
            _authOption = authOption.Value;
            _authValidation = authValidation;
        }

        public void Configure(JwtBearerOptions options)
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _authOption.Issuer,
                ValidAudience = _authOption.Audience,
                IssuerSigningKey = _authValidation.SecurityKey
            };
        }
    }
}