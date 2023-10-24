using Api.Authentication;
using AutoMapper;
using Business.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Dto.Master;
using Models.Master;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokensController : ControllerBase
    {
        readonly ITokenProvider RepoToken;
        readonly BIUser RepoUser;
        readonly IMapper Mapper;
       
        public TokensController(ITokenProvider repoToken, BIUser repoUser, IMapper mapper)
        {
            RepoToken = repoToken;
            RepoUser = repoUser;
            Mapper = mapper;
        }
        [HttpPost]
        public async Task<ActionResult> Token(Login login)
        {
            var org = await RepoUser.Login(login);
          
            if (org == null)
                return BadRequest();
            DateTime expiry =  DateTime.Now.AddMinutes(60);
            DateTime dateNow =  DateTime.Now;

           
            int expiryTime = ((int)((expiry.Ticks - dateNow.Ticks) / TimeSpan.TicksPerSecond));

            var token = new JsonWebToken()
            {
                Access_Token = RepoToken.CreateToken(login, expiry,org.SlugTenant),
                Expires_In = expiryTime + 1,
                StatusCode = 200
            };
            return Ok(token);
        }
    }
}
