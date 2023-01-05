using MediatR;
using Microsoft.IdentityModel.Tokens;
using SSO.Api.Model; 
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SSO.Api.Security.Identities
{
    public class JWTHelper : IJWTHelper
    {

        private readonly IMediator _mediator;

        public JWTHelper(IMediator mediator)
        {
            _mediator = mediator;
        }

        public ClaimsPrincipal GetPrincipal(string token, string jwtSecurityKey)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                if (tokenHandler.ReadToken(token) is not JwtSecurityToken)
                    return null;
                var symmetricKey = Encoding.UTF8.GetBytes(jwtSecurityKey);
                var validationParameters = new TokenValidationParameters()
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(symmetricKey)
                };
                var principal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken securityToken);
                return principal;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string CreateToken(AthenticatedUser user, string jwtSecurityKey)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecurityKey));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
                    new Claim(ClaimTypes.Name,Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.MobilePhone,user.MobileNo,typeof(string).ToString()),
                }),
                IssuedAt = DateTime.Now,
                Expires = DateTime.UtcNow.AddMonths(4),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var generatedToken = tokenHandler.WriteToken(token);
            return generatedToken;
        }

        public bool ValidateToken(string token, out AthenticatedUser user, string jwtSecurityKey)
        {
            user = null;
            var simplePrinciple = GetPrincipal(token, jwtSecurityKey);
            var identity = simplePrinciple?.Identity as ClaimsIdentity;
            if (identity == null)
                return false;
            if (!identity.IsAuthenticated)
                return false;
            var userIdClaim = identity.FindFirst(ClaimTypes.NameIdentifier);
            var passwordSecurityCode = identity.FindFirst(ClaimTypes.Hash)?.Value;
            var userId = int.Parse(userIdClaim?.Value);  
 
            return true;
        }
    }
}
