using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using Microsoft.IdentityModel.Tokens;

namespace Smash_Combos.Controllers
{
    public class TokenGenerator
    {
        private string JWT_KEY;

        public TokenGenerator(string key)
        {
            JWT_KEY = key;
        }

        public string TokenFor(Object user)
        {
            var claims = JsonSerializer.Deserialize<JsonElement>(JsonSerializer.Serialize(user)).
                            EnumerateObject().Select(
                                property => new Claim(property.Name, property.Value.ToString())).
                            ToArray();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(10),
                SigningCredentials = SigningCredentials()
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }

        public SigningCredentials SigningCredentials()
        {
            return new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JWT_KEY)),
                                          SecurityAlgorithms.HmacSha256Signature);
        }
    }
}
