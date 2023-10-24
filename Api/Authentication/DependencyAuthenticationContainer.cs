using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Authentication
{
    public static class DependencyAuthenticationContainer
    {
        public static IServiceCollection AddAuthenticationToken(this IServiceCollection services)
        {

            var tokenPro = new JwtProvider("issuer", "audience", "norn");
            services.AddSingleton<ITokenProvider>(tokenPro);
            services.AddAuthentication(IISDefaults.AuthenticationScheme);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                {
                    opt.RequireHttpsMetadata = true;
                    opt.TokenValidationParameters = tokenPro.GetTokenValidation();
                    opt.SaveToken = true;
                });
            services.AddAuthorization(auth =>
            {
                auth.DefaultPolicy = new AuthorizationPolicyBuilder()
                .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                .RequireAuthenticatedUser()
                .Build();
            });
            return services;
        }
    }
}
