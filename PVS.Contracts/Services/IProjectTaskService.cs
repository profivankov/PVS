using PVS.Contracts.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PVS.Contracts.Services
{
    public interface IProjectTaskService
    {
        Task<ProjectTaskDTO> GetAsync(Guid id);
        Task<IEnumerable<ProjectTaskDTO>> GetAllAsync();
        Task<Guid> CreateAsync(ProjectTaskDTO model);
        Task DeleteAsync(Guid id);
        Task<ProjectTaskDTO> EditAsync(ProjectTaskDTO model);
    }
}
