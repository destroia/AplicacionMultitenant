using Data.Organizations;
using Models.Master;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Organizations
{
    public class BOrganization : BIOrganization
    {
        readonly DIOrganization Repo ;
        public BOrganization(DIOrganization repo)
        {
            Repo = repo;
        }

        public async Task<Organization> Create(Organization organization)
        {
            try
            {
                return await Repo.Create(organization);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<IEnumerable<Organization>> GetAll()
        {
            try
            {
                return await Repo.GetAll();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
