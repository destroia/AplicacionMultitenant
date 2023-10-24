using Microsoft.IdentityModel.Tokens;
using Models.Dto.Master;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Api.Authentication
{
    public class JwtProvider: ITokenProvider
    {
        RsaSecurityKey Key;
        string Algoritmo;
        string Issuer;
        string Audience;
        public JwtProvider(string issuer, string audience, string keyName)
        {

            var provider = new RSACryptoServiceProvider(2048);

            Key = new RsaSecurityKey(provider);
            Algoritmo = SecurityAlgorithms.RsaSha256Signature;
            Issuer = issuer;
            Audience = audience;
        }
        public string CreateToken(Login login, DateTime expiry,string slugTenant)
        {
            JwtSecurityTokenHandler TokenHandler = new JwtSecurityTokenHandler();

            var identity = new ClaimsIdentity(new List<Claim>() {
                new Claim(ClaimTypes.Name,login.Email),
                new Claim(ClaimTypes.Role,login.Password),
                 new Claim("SlugTenant",slugTenant)
            }, "Customer");

            SecurityToken Token = TokenHandler.CreateJwtSecurityToken(new SecurityTokenDescriptor()
            {
                Audience = Audience,
                Issuer = Issuer,
                SigningCredentials = new SigningCredentials(Key, Algoritmo),
                Expires = expiry.ToUniversalTime(),
                Subject = identity
            });
            return TokenHandler.WriteToken(Token);
        }

        public TokenValidationParameters GetTokenValidation()
        {
            return new TokenValidationParameters()
            {
                IssuerSigningKey = Key,
                ValidAudience = Audience,
                ValidIssuer = Issuer,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.FromSeconds(0)
            };
        }
    }
}
