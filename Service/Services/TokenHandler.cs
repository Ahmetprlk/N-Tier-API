using Core.Models;
using Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class TokenHandler : ITokenHandler
    {
        private readonly IConfiguration configuration;

        public TokenHandler(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string CreateRefreshToken()
        {
            byte[] number = new byte[32];
            using RandomNumberGenerator random =RandomNumberGenerator.Create();
            random.GetBytes(number);
            return Convert.ToBase64String(number);
        }

        public Token CreateToken(User user, List<Role> roles)
        {
            var token = new Token();

            SymmetricSecurityKey securitykey = new(Encoding.UTF8.GetBytes(configuration["Token:SecurityKey"]));

            SigningCredentials signingCredentials = new(securitykey,SecurityAlgorithms.HmacSha256);
            token.Expiration = DateTime.Now.AddDays(7);

            JwtSecurityToken jwtSecurityToken = new(
                issuer : configuration["Token:Issuer"],
                audience: configuration["Token:Audience"],
                expires: token.Expiration,
                claims :SetClaims(user, roles),
                notBefore: DateTime.Now
                );

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new();
            token.AccessToken =jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);
            token.RefreshToken = CreateRefreshToken();
            return token;

        }


        public IEnumerable<Claim> SetClaims(User user, List<Role> roles)
        {
            Claim claim = new("sub",user.ID.ToString());
            List<Claim> claims = new List<Claim>();

            claims.Add(claim);
            //claims.AddName(user.Name);
            //claims.AddRoles(roles.Select(p => p.Name).ToArray());

            return claims;

        }
    }
}
