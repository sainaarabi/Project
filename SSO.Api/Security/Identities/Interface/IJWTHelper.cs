using SSO.Api.Model;
using System.Security.Claims;

namespace SSO.Api.Security.Identities
{
    public interface IJWTHelper
    {
        ClaimsPrincipal GetPrincipal(string token, string jwtSecurityKey);
        bool ValidateToken(string token, out AthenticatedUser user, string jwtSecurityKey);
        string CreateToken(AthenticatedUser user, string jwtSecurityCode);
    }
}
