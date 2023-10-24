using Business.Organizations;
using Business.Products;
using Business.Tenant;
using Business.Users;
using Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Business
{
    public static class DependencyContainer
    {
        public static  IServiceCollection AddDependencyBusiness(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<BIOrganization, BOrganization>();
            services.AddScoped<BITenant, BTenant>();
            services.AddScoped<BIUser, BUser>();
            services.AddScoped<BIProduct, BProduct>();
            services.AddContexDb(configuration);

            return services;
        }
    }
}
