using Models.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Organizations
{
    public interface DIOrganization
    {
        Task<IEnumerable<Organization>> GetAll();
        Task<Organization> Create(Organization organization);
    }
}
