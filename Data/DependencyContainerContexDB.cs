using Data.Films;
using Data.Organizations;
using Data.Products;
using Data.Tenants;
using Data.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Data
{
    public static class DependencyContainerContexDB
    {
        public static IServiceCollection AddContexDb(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<DITenant, DTenant>();
            services.AddScoped<DIUser, DUser>();
            services.AddScoped<DIOrganization, DOrganization>();
            services.AddScoped<DIProduct, DProduct>();
            services.AddScoped<DIFilm, DFilm>();

            services.AddDbContext<ContextDBMaster>(options => options.UseSqlServer(configuration.GetConnectionString("ConnectionMainOrganizacionUsuario")));
            services.AddDbContext<ContextDBTenant>(options => options.UseSqlServer(configuration.GetConnectionString("ConnectionMainProductoOrganizacion")));

            return services;
        }

    }
}
