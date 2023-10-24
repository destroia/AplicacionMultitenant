using Data.Tenants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Tenant
{
    public class BTenant : BITenant
    {
        readonly DITenant Tenant;
        public BTenant(DITenant tenant)
        {
            Tenant = tenant;
        }
        public bool SetTenant(string tenant,bool createNewDB = false)
        {
            try
            {
                return Tenant.GetConnectionString(tenant, createNewDB); 
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
