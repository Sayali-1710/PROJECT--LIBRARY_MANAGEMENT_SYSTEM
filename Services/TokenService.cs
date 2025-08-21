using Microsoft.IdentityModel.Tokens;
using PROJECT__LIBRARY_MANAGEMENT_SYSTEM.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PROJECT__LIBRARY_MANAGEMENT_SYSTEM.Services
{
    public class TokenService:ITokenService
    {
        private readonly IConfiguration _configuration;
        public TokenService(IConfiguration configuration)
        {
            _configuration =configuration;
        }
        public string GenerateToken( User user)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var secretkey = jwtSettings["Secretkey"];
            var expiryMinutes = int.Parse(jwtSettings["ExpiryMinutes"]??"60");
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
                new Claim(ClaimTypes.Name,user.Name),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Role,user.Role.ToString())
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretkey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expiryMinutes),
                signingCredentials: creds
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }

}
