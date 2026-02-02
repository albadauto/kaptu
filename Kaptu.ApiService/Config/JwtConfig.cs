using Kaptu.DLL.DTO;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Kaptu.ApiService.Config
{
    public static class JwtConfig
    {
        public static string GenerateToken(UserDTO user)
        {
            var claims = new[] { new Claim(ClaimTypes.Email, user.Email) };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("660ae2c4b5ae51d212b822a1bf7c316238c6689f"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(signingCredentials: creds, expires: DateTime.Now.AddHours(2), claims: claims);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
