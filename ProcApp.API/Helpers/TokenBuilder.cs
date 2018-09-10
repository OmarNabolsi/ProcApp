using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProcApp.API.Models;

namespace ProcApp.API.Helpers
{
    public class TokenBuilder : ITokenBuilder
    {
        private readonly IConfiguration _config;
        public TokenBuilder(IConfiguration config)
        {
            _config = config;
        }
        public object BuildToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username)
            };

            var appSettingsToken = Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value);

            var key = new SymmetricSecurityKey(appSettingsToken);

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new { token = tokenHandler.WriteToken(token) };
        }
    }
}