using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Tenant
{
    public interface BITenant
    {
        bool SetTenant(string tenant, bool createNewDB = false);
    }
}
