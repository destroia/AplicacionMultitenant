using Business.Films;
using Microsoft.AspNetCore.Mvc;
using Models.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class FilmsController : ControllerBase
    {
        readonly BIFilm Repo;
        public FilmsController(BIFilm repo)
        {
            Repo = repo;
        }
        // GET: api/<FilmsController>
        [HttpGet]
        public async Task<IEnumerable<Film>> GetAll()
        {
            return await Repo.GetAll();
        }

        // GET api/<FilmsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FilmsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<FilmsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FilmsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
