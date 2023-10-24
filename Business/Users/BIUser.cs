using Models.Dto.Master;
using Models.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Users
{
    public interface BIUser
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> Create(User user);
        Task<Organization> Login(Login user);
    }
}
