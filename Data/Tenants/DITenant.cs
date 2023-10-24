using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Tenants
{
    public interface DITenant
    {
        bool GetConnectionString(string tenant, bool createNewDB = false);
    }
}
