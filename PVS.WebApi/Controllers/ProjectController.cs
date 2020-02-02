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
    [Route("api/projects")]
    [ApiController]
    public class ProjectController : ApiController
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet("{id}")]
        public async Task<ProjectDTO> GetAsync(Guid id)
        {
            var project = await _projectService.GetAsync(id);
            return project;
        }

        [HttpGet("byuser/{id}")]
        public async Task<IEnumerable<ProjectDTO>> GetByUserAsync(Guid id)
        {
            var projectList = await _projectService.GetByUserIdAsync(id);
            return projectList;
        }

        [HttpGet]
        public async Task<IEnumerable<ProjectDTO>> GetAllAsync()
        {
            var projectList = await _projectService.GetAllAsync();
            return projectList;
        }

        [HttpPost]
        public async Task<BaseModel> CreateAsync([FromBody] ProjectDTO model)
        {
            if (!TryValidateModel(model))
            {
                throw new Exception("400");
            }

            var id = await _projectService.CreateAsync(model);
            return IdResponse(id);
        }

        [HttpDelete("{id}")]
        public Task DeleteAsync(Guid id)
        {
            return _projectService.DeleteAsync(id);
        }

        [HttpPut]
        public async Task<ProjectDTO> EditAsync([FromBody] ProjectDTO model)
        {
            if (!TryValidateModel(model))
            {
                throw new Exception("400");
            }

            return await _projectService.EditAsync(model);
        }
    }
}
