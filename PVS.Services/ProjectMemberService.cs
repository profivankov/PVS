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
    public class ProjectMemberService : IProjectMemberService
    {
        private readonly IProjectMemberRepository _projectMemberRepository;
        public ProjectMemberService(IProjectMemberRepository projectMemberRepository)
        {
            _projectMemberRepository = projectMemberRepository;
        }

        public async Task<ProjectMemberDTO> GetAsync(Guid id)
        {
            var entity = await _projectMemberRepository.GetByIdAsync(id);
            if (entity == null)
            {
                throw new Exception("Project member not found");
            }
            return entity.ToModel();
        }

        public async Task<IEnumerable<ProjectMemberDTO>> GetAllAsync()
        {
            var query = await _projectMemberRepository.GetAllAsync();
            var model = query.Select(project => project.ToModel());
            return model;
        }

        public async Task<Guid> CreateAsync(ProjectMemberDTO model)
        {
            var entity = new ProjectMember()
            {
                ProjectId = model.ProjectId,
                UserId = model.UserId,
                Role = model.Role,
                JoinDate = model.JoinDate
            };

            await _projectMemberRepository.InsertAsync(entity);
            await _projectMemberRepository.SaveAsync();
            return entity.UserId;
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _projectMemberRepository.GetByIdAsync(id);
            if (entity == null)
            {
                throw new Exception("Project member not found");
            }
            _projectMemberRepository.Delete(entity);
            await _projectMemberRepository.SaveAsync();
        }

        public async Task<ProjectMemberDTO> EditAsync(ProjectMemberDTO model)
        {
            var entity = await _projectMemberRepository.GetByIdAsync(model.ProjectId);
            if (entity == null)
            {
                throw new Exception("Project member not found");
            }

            entity.ProjectId = model.ProjectId;
            entity.UserId = model.UserId;
            entity.Role = model.Role;
            entity.JoinDate = model.JoinDate;
            _projectMemberRepository.Update(entity);
            await _projectMemberRepository.SaveAsync();

            return entity.ToModel();
        }
    }
}
