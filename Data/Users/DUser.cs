using Microsoft.EntityFrameworkCore;
using Models.Dto.Master;
using Models.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Users
{
    public class DUser : DIUser
    {
        readonly ContextDBMaster DB;
        public DUser(ContextDBMaster db)
        {
            DB = db;
        }

        public async Task<User> Create(User user)
        {
            try
            {
                var result = await DB.Users.AddAsync(user);
                await DB.SaveChangesAsync();

                return result.Entity;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            try
            {
                return await DB.Users.ToListAsync();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Organization> Login(Login login)
        {
            try
            {
                var userObj = await DB.Users.Join(DB.Organizations, u => u.OrganizationId, o => o.Id, (u, o) => new { u, o })
                    .FirstOrDefaultAsync(x => x.u.Email == login.Email && x.u.Password == login.Password);

                if (userObj != null)
                    return userObj.o;
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
