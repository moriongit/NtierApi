using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Twitter.Business.Dtos.AuthDtos;
using Twitter.Business.ExternalServices.Interfaces;
using Twitter.Core.Entities;

namespace Twitter.Business.ExternalServices.Implements
{
    internal class TokenService : ITokenService
    {
        IConfiguration _config {  get; }

        public TokenService (IConfiguration config)
        {
            _config = config;
        }
        public TokenDto CreateToken(TokenParamsDto dto)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, dto.User.UserName));
            //claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
            claims.Add(new Claim(ClaimTypes.GivenName, dto.User.Fullname));
            claims.Add(new Claim(ClaimTypes.Role, dto.Role));
            //claims.Add(new Claim("Birth", user.BirthDate.ToString()));

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            SigningCredentials cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            DateTime expires = DateTime.UtcNow.AddMinutes(Convert.ToInt32(_config.GetSection("Jwt")?["ExpireMin"]));
            JwtSecurityToken jwt = new JwtSecurityToken(_config.GetSection("Jwt")?["Issuer"],
                _config.GetSection("Jwt")?["Audience"],
                claims,
                DateTime.UtcNow,
                expires,
                cred
                );
            JwtSecurityTokenHandler jwtHandler = new JwtSecurityTokenHandler();
            var token = jwtHandler.WriteToken(jwt);
            return new TokenDto 
            {
                Expires = expires,
                Token = token
            };
        }
    }
}
