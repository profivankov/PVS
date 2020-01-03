using PVS.Contracts.DTO;
using PVS.Contracts.Services;
using PVS.Entities;
using PVS.Persistance.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVS.Services
{
    public class ProjectTaskService : IProjectTaskService
    {
        private readonly IProjectTaskRepository _projectTaskRepository;
        public ProjectTaskService(IProjectTaskRepository projectTaskRepository)
        {
            _projectTaskRepository = projectTaskRepository;
        }

        public async Task<ProjectTaskDTO> GetAsync(Guid id)
        {
            var entity = await _projectTaskRepository.GetByIdAsync(id);
            if (entity == null)
            {
                throw new Exception("Project task not found");
            }
            return entity.ToModel();
        }

        public async Task<IEnumerable<ProjectTaskDTO>> GetAllAsync()
        {
            var query = await _projectTaskRepository.GetAllAsync();
            var model = query.Select(project => project.ToModel());
            return model;
        }

        public async Task<Guid> CreateAsync(ProjectTaskDTO model)
        {
            var entity = new ProjectTask()
            {
                Id = Guid.NewGuid(),
                ProjectId = model.ProjectId,
                TaskFatherId = model.TaskFatherId,
                TaskName = model.TaskName
            };

            await _projectTaskRepository.InsertAsync(entity);
            await _projectTaskRepository.SaveAsync();
            return entity.Id;
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _projectTaskRepository.GetByIdAsync(id);
            if (entity == null)
            {
                throw new Exception("Project task not found");
            }
            _projectTaskRepository.Delete(entity);
            await _projectTaskRepository.SaveAsync();
        }

        public async Task<ProjectTaskDTO> EditAsync(ProjectTaskDTO model)
        {
            var entity = await _projectTaskRepository.GetByIdAsync(model.ProjectId);
            if (entity == null)
            {
                throw new Exception("Project task not found");
            }

            entity.ProjectId = model.ProjectId;
            entity.TaskFatherId = model.TaskFatherId;
            entity.TaskName = model.TaskName;
            _projectTaskRepository.Update(entity);
            await _projectTaskRepository.SaveAsync();

            return entity.ToModel();
        }
    }
}
