using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RealEstate_Dapper_Api.Tools
{
    public class JwtTokenGenerator
    {
        public static TokenResponseViewModel GenerateToken(GetCheckAppUserViewModel model)
        {
            var _claims = new List<Claim>();
            if (!string.IsNullOrWhiteSpace(model.Role))
                _claims.Add(new Claim(ClaimTypes.Role, model.Role));
            else
                _claims.Add(new Claim(ClaimTypes.NameIdentifier, model.id.ToString()));

            if (!string.IsNullOrWhiteSpace(model.UserName))
                _claims.Add(new Claim("Username", model.UserName));
            else
                _claims.Add(new Claim(ClaimTypes.NameIdentifier, model.id.ToString()));

            var _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key));
            var _signinCredentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);
            var _expireDate = DateTime.UtcNow.AddDays(JwtTokenDefaults.Expire);
            JwtSecurityToken token = new JwtSecurityToken(issuer: JwtTokenDefaults.ValidIssuer, audience: JwtTokenDefaults.ValidAudience, claims: _claims, notBefore: DateTime.UtcNow, expires: _expireDate, signingCredentials: _signinCredentials);
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            return new TokenResponseViewModel(tokenHandler.WriteToken(token), _expireDate);
        }
    }
}
