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
    [Route("projects/tasks")]
    [ApiController]
    public class ProjectTaskController : ApiController
    {
        private readonly IProjectTaskService _projectTaskService;

        public ProjectTaskController(IProjectTaskService projectTaskService)
        {
            _projectTaskService = projectTaskService;
        }

        [HttpGet("{id}")]
        public async Task<ProjectTaskDTO> GetAsync(Guid id)
        {
            var projectTask = await _projectTaskService.GetAsync(id);
            return projectTask;
        }

        [HttpGet]
        public async Task<IEnumerable<ProjectTaskDTO>> GetAllAsync()
        {
            var projectTaskList = await _projectTaskService.GetAllAsync();
            return projectTaskList;
        }

        [HttpPost]
        public async Task<BaseModel> CreateAsync([FromBody] ProjectTaskDTO model)
        {
            if (!TryValidateModel(model))
            {
                throw new Exception("400");
            }

            var id = await _projectTaskService.CreateAsync(model);
            return IdResponse(id);
        }

        [HttpDelete("{id}")]
        public Task DeleteAsync(Guid id)
        {
            return _projectTaskService.DeleteAsync(id);
        }

        [HttpPut]
        public async Task<ProjectTaskDTO> EditAsync([FromBody] ProjectTaskDTO model)
        {
            if (!TryValidateModel(model))
            {
                throw new Exception("400");
            }

            return await _projectTaskService.EditAsync(model);
        }
    }
}
