using AutoMapper;
using Business.Products;
using Business.Tenant;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Dto.Tenant;
using Models.Tenant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("{tenant}/[controller]")]
    [ApiController]
    [Authorize]

    public class ProductsController : ControllerBase
    {
        readonly BIProduct Repo;
        readonly BITenant Tanent;
        readonly IMapper Mapper;
        public ProductsController(BITenant tanent, BIProduct repo, IMapper mapper)
        {
            Repo = repo;
            Tanent = tanent;
            Mapper = mapper;
        }
        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll()
        {
            string tenant = HttpContext.Items["Tenant"] as string;
            Tanent.SetTenant(tenant);

            var result = await Repo.GetAll();
            var resultDto = Mapper.Map<List<ProductDto>>(result);

            return Ok(resultDto);
        }
        // POST api/<ProductsController>
        [HttpPost]
        public async Task<ActionResult<ProductDto>> Create(ProductDto productDto)
        {
            string tenant = HttpContext.Items["Tenant"] as string;
            Tanent.SetTenant(tenant);

            var product = Mapper.Map<Product>(productDto);
            var result = await Repo.Create(product);
            if (result == null)
                return BadRequest();
            var resultDto = Mapper.Map<ProductDto>(result);

            return Ok(resultDto);
        }

        // PUT api/<ProductsController>/5
        [HttpPut]
        public async Task<ActionResult<ProductDto>> Update(ProductDto productDto)
        {
            string tenant = HttpContext.Items["Tenant"] as string;
            Tanent.SetTenant(tenant);

            var product = Mapper.Map<Product>(productDto);
            var result = await Repo.Update(product);
            if (result == null)
                return BadRequest();
            var resultDto = Mapper.Map<ProductDto>(result);
            return Ok(resultDto);
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            string tenant = HttpContext.Items["Tenant"] as string;
            Tanent.SetTenant(tenant);

            var result = await Repo.Delete(id);
            return result == true ? Ok(result) : BadRequest(result);
        }
    }
}
