using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dto.Master
{
    public class UserDto
    {
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
