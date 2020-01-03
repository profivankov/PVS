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
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<ProjectDTO> GetAsync(Guid id)
        {
            var entity = await _projectRepository.GetByIdAsync(id);
            if (entity == null)
            {
                throw new Exception("Project not found");
            }
            return entity.ToModel();
        }

        public async Task<IEnumerable<ProjectDTO>> GetAllAsync()
        {
            var query = await _projectRepository.GetAllAsync();
            var model = query.Select(project => project.ToModel());
            return model;
        }

        public async Task<Guid> CreateAsync(ProjectDTO model)
        {
            var entity = new Project()
            {
                Id = Guid.NewGuid(),
                UserId = model.UserId,
                ProjectName = model.ProjectName,
                Description = model.Description
            };

            await _projectRepository.InsertAsync(entity);
            await _projectRepository.SaveAsync();
            return entity.Id;
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _projectRepository.GetByIdAsync(id);
            if (entity == null)
            {
                throw new Exception("Project not found");
            }
            _projectRepository.Delete(entity);
            await _projectRepository.SaveAsync();
        }

        public async Task<ProjectDTO> EditAsync(ProjectDTO model)
        {
            var entity = await _projectRepository.GetByIdAsync(model.Id);
            if (entity == null)
            {
                throw new Exception("Project not found");
            }

            entity.UserId = model.UserId;
            entity.ProjectName = model.ProjectName;
            entity.Description = model.Description;
            _projectRepository.Update(entity);
            await _projectRepository.SaveAsync();

            return entity.ToModel();
        }
    }
}
