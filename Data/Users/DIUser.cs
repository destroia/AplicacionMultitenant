using Models.Dto.Master;
using Models.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Users
{
    public interface DIUser
    {
        Task<User> Create(User user);
        Task<IEnumerable<User>> GetAll();
        Task<Organization> Login(Login login);
    }
}
