using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Music_app.Domain.Commons;
using Music_app.Domain.Consts;
using Music_app.Domain.Models;
using Music_app.Infrastructure.Configurations;

namespace Music_app.Infrastructure.Services
{
    public class AuthProvider : IAuthProvider
    {
        private readonly AppSetting _appSetting = new();
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly AuthOption _authOption;
        private readonly AuthValidation _authValidation;
        
        public AuthProvider(
            IOptions<AuthOption> authOption,
            IHttpContextAccessor httpContextAccessor,
            AuthValidation authValidation)
        {
            _authOption = authOption.Value;
            _httpContextAccessor = httpContextAccessor;
            _authValidation = authValidation;
        }
        
        public string GenerateAccessTokenAsync(ClaimTypeDto claim)
        {
            var claims = new Claim[ ]
            {
                new(ClaimTypeConst.Id, claim.id),
                new(ClaimTypeConst.UserName, claim.user_name),
                new(ClaimTypeConst.Email, claim.email),
                new(ClaimTypeConst.Phone, claim.phone_number),
                new(ClaimTypes.Role, claim.role),
                new(ClaimTypeConst.RefreshToken, claim.refresh_token)
            };
            
            // var identity = new ClaimsIdentity(claims, _appSetting.cookieSettings.Name);
            var token = new JwtSecurityToken(
                _authOption.Issuer,
                _authOption.Audience,
                claims,
                null,
                DateTime.UtcNow.AddHours(_authValidation.ExpireTime),
                _authValidation.GetSigning());
            
            var accessToken = new JwtSecurityTokenHandler().WriteToken(token);
            
            // await SigningAsync(identity);
            SaveCookiesStorage(accessToken);
            return accessToken;
        }

        public void SaveCookiesStorage(string token)
        {
            if (_httpContextAccessor.HttpContext != null)
            {
                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    Expires = DateTime.UtcNow.AddHours(_authValidation.ExpireTime)
                };

                _httpContextAccessor.HttpContext.Response.Cookies.Append("accessToken", token, cookieOptions);
            }
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        // public async Task SignOutAsync()
        // {
        //     if (_httpContextAccessor.HttpContext != null)
        //     {
        //         await _httpContextAccessor.HttpContext.SignOutAsync(_appSetting.cookieSettings.Name);
        //     }
        // }

        // private async Task SigningAsync(IIdentity claimsIdentity)
        // {
        //     var principal = new ClaimsPrincipal(claimsIdentity);
        //     if (_httpContextAccessor.HttpContext != null)
        //     {
        //         await _httpContextAccessor.HttpContext.SignInAsync(_appSetting.cookieSettings.Name, principal);
        //     }
        // }
    }
}