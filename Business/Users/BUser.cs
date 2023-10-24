using Data;
using Data.Users;
using Microsoft.EntityFrameworkCore;
using Models.Dto.Master;
using Models.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Users
{
    public class BUser : BIUser
    {
        readonly DIUser Repo;
        public BUser(DIUser repo)
        {
            Repo = repo;
        }

        public async Task<User> Create(User user)
        {
            try
            {
                return await Repo.Create(user);
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
                return await Repo.GetAll();
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
                return await Repo.Login(login);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
