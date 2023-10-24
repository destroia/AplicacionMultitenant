using AutoMapper;
using Business.Organizations;
using Business.Tenant;
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
    public class OrganizationsController : ControllerBase
    {
        readonly BIOrganization RepoOrg;
        readonly BITenant RepoTenant;
        readonly IMapper Mapper;


        public OrganizationsController(BIOrganization repoOrg,BITenant repoTenant,IMapper mapper)
        {
            RepoOrg = repoOrg;
            RepoTenant = repoTenant;
            Mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrganizationDto>>> GetAll()
        {
            var result = await RepoOrg.GetAll();
            var resultDto = Mapper.Map<List<OrganizationDto>>(result);
            return Ok(resultDto);
        }
        [HttpPost]
        public async Task<ActionResult<OrganizationDto>> Create(OrganizationDto organizationDto)
        {
            var organization = Mapper.Map<Organization>(organizationDto);
            var result = await RepoOrg.Create(organization);
            if(result != null)
                RepoTenant.SetTenant(organization.SlugTenant,true);
            var resultDto = Mapper.Map<OrganizationDto>(result);

            return result != null ? Ok(resultDto) : BadRequest(resultDto);
        }
    }
}
