using Microsoft.EntityFrameworkCore;
using Models.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Organizations
{
    public class DOrganization : DIOrganization
    {
        readonly ContextDBMaster DB;
        public DOrganization(ContextDBMaster db)
        {
            DB = db;
        }

        public async Task<Organization> Create(Organization organization)
        {
            try
            {
                var result = await DB.Organizations.AddAsync(organization);
                await DB.SaveChangesAsync();

                return result.Entity;
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
                return await DB.Organizations.ToListAsync();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
