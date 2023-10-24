using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Authentication
{
    public class JsonWebToken
    {
        public int StatusCode { get; set; }
        public string Access_Token { get; set; }
        public string Token_Type { get; set; } = "bearer";
        public int Expires_In { get; set; }
        public string Refresh_Token { get; set; }
    }
}
