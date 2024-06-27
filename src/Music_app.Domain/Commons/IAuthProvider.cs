using Music_app.Domain.Models;

namespace Music_app.Domain.Commons
{
    public interface IAuthProvider
    {
        string GenerateAccessTokenAsync(ClaimTypeDto claim);
        void SaveCookiesStorage(string token);
        string GenerateRefreshToken();
        // Task SignOutAsync();
        // Task<bool> VerifyAccessTokenAsync(string token);
    }
}