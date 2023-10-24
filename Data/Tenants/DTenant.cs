using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Tenants
{
    public class DTenant : DITenant
    {
        readonly IConfiguration Config;
        private readonly ContextDBTenant TenantDbContext;
        public DTenant(IConfiguration config, ContextDBTenant tenantDbContext)
        {
            Config = config;
            TenantDbContext = tenantDbContext;
        }

        public bool GetConnectionString(string tenant, bool createNewDB = false)
        {
            string connection = $"Data Source=.;Initial Catalog=AppMultiTenant_{tenant}_DB;Integrated Security=true";//Config.GetConnectionString(tenant);

            return UpdateDatabase(connection, createNewDB);
        }
        public bool UpdateDatabase(string tenantConnection,bool createNewDB)
        {
            try
            {
                TenantDbContext.Database.GetDbConnection().ConnectionString = tenantConnection;
                if (createNewDB)
                {
                    TenantDbContext.Database.EnsureCreated();
                    TenantDbContext.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
           
        }
    }
}
