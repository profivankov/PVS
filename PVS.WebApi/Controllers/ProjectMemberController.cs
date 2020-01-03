using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PVS.Contracts.DTO;
using PVS.Contracts.Services;
using PVS.WebApi.Infrastructure;
using PVS.WebApi.Models;

namespace PVS.WebApi.Controllers
{
    [Route("projects/members")]
    [ApiController]
    public class ProjectMemberController : ApiController
    {
        private readonly IProjectMemberService _projectMemberService;

        public ProjectMemberController(IProjectMemberService projectMemberService)
        {
            _projectMemberService = projectMemberService;
        }

        [HttpGet("{id}")]
        public async Task<ProjectMemberDTO> GetAsync(Guid id)
        {
            var projectMember = await _projectMemberService.GetAsync(id);
            return projectMember;
        }

        [HttpGet]
        public async Task<IEnumerable<ProjectMemberDTO>> GetAllAsync()
        {
            var projectMemberList = await _projectMemberService.GetAllAsync();
            return projectMemberList;
        }

        [HttpPost]
        public async Task<BaseModel> CreateAsync([FromBody] ProjectMemberDTO model)
        {
            if (!TryValidateModel(model))
            {
                throw new Exception("400");
            }

            var id = await _projectMemberService.CreateAsync(model);
            return IdResponse(id);
        }

        [HttpDelete("{id}")]
        public Task DeleteAsync(Guid id)
        {
            return _projectMemberService.DeleteAsync(id);
        }

        [HttpPut]
        public async Task<ProjectMemberDTO> EditAsync([FromBody] ProjectMemberDTO model)
        {
            if (!TryValidateModel(model))
            {
                throw new Exception("400");
            }

            return await _projectMemberService.EditAsync(model);
        }
    }
}
