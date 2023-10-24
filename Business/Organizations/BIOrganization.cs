using Models.Master;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Organizations
{
    public interface BIOrganization
    {
        Task<IEnumerable<Organization>> GetAll();
        Task<Organization> Create(Organization organization);
    }
}
