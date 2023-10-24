using AutoMapper;
using Business.Users;
using Microsoft.AspNetCore.Mvc;
using Models.Dto.Master;
using Models.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly IMapper Mapper;
        readonly BIUser Repo;
        public UsersController(BIUser repo, IMapper mapper)
        {
            Repo = repo;
            Mapper = mapper;
        }
        // GET: api/<UsersController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> Get()
        {
            var result = await Repo.GetAll();
            var resultDto = Mapper.Map<List<UserDto>>(result);

            return  Ok(resultDto);
        }

       
        // POST api/<UsersController>
        [HttpPost]
        public async Task<ActionResult<UserDto>> Create(UserDto userDto)
        {
            var user = Mapper.Map<User>(userDto);
            var result = await Repo.Create(user);
            var resultDto =  Mapper.Map<UserDto>(result);

            return resultDto != null ? Ok(resultDto) : BadRequest(resultDto);
        }
    }
}
