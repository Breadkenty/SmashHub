using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace Smash_Combos.Core
{
    public class TokenGenerator
    {
        private readonly string JWT_KEY;

        public TokenGenerator(string key)
        {
            JWT_KEY = key;
        }

        public string TokenFor(Object payload)
        {
            var claims = JsonSerializer.Deserialize<JsonElement>(JsonSerializer.Serialize(payload)).
                            EnumerateObject().Select(
                                property => new Claim(property.Name, property.Value.ToString())).
                            ToArray();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(10),
                SigningCredentials = SigningCredentials(),
                Issuer = "https://smash-combos.herokuapp.com"
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }

        public bool ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            if (tokenHandler.CanReadToken(token) && tokenHandler.CanValidateToken)
            {
                var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JWT_KEY));
                try
                {
                    tokenHandler.ValidateToken(token, new TokenValidationParameters
                    {
                        ValidateAudience = false,
                        ValidateActor = false,
                        ValidateLifetime = false,
                        ValidateTokenReplay = false,
                        ValidateIssuer = true,
                        ValidIssuer = "https://smash-combos.herokuapp.com",
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = securityKey
                    }, out SecurityToken validatedToken);

                    return true;
                }
                catch
                {
                    throw new ArgumentException("Invalid JWT token");
                }
            }
            else
            {
                throw new ArgumentException("Can't read or validate JWT token");
            }
        }

        public SigningCredentials SigningCredentials()
        {
            return new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JWT_KEY)),
                                          SecurityAlgorithms.HmacSha256Signature);
        }
    }
}
