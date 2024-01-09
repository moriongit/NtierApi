using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Twitter.Business.ExternalServices.Interfaces;
using Twitter.Core.Entities;

namespace Twitter.Business.ExternalServices.Implements
{
    internal class TokenService : ITokenService
    {
        public string CreateToken(AppUser user)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.UserName));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
            claims.Add(new Claim(ClaimTypes.GivenName, user.Fullname));
            claims.Add(new Claim("Birth", user.BirthDate.ToString()));

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("3fdc7710-9793-49c5-b03c-481de0ce1ce7"));
            SigningCredentials cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            JwtSecurityToken jwt = new JwtSecurityToken("https://localhost:7297/",
                "https://localhost:7297/api",
                null,
                DateTime.UtcNow,
                DateTime.UtcNow.AddHours(24),
                cred
                );
            JwtSecurityTokenHandler jwtHandler = new JwtSecurityTokenHandler();
            var token = jwtHandler.WriteToken(jwt);
            return token;
        }
    }
}
