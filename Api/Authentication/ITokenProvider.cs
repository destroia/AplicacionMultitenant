using Microsoft.IdentityModel.Tokens;
using Models.Dto.Master;
using System;

namespace Api.Authentication
{
    public interface ITokenProvider
    {
        string CreateToken(Login login, DateTime expiry,string slugTenant);
        TokenValidationParameters GetTokenValidation();
    }
}
