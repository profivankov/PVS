using PVS.Contracts.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PVS.Contracts.Services
{
    public interface IProjectService
    {
        Task<ProjectDTO> GetAsync(Guid id);
        Task<IEnumerable<ProjectDTO>> GetByUserIdAsync(Guid id);
        Task<IEnumerable<ProjectDTO>> GetAllAsync();
        Task<Guid> CreateAsync(ProjectDTO model);
        Task DeleteAsync(Guid id);
        Task<ProjectDTO> EditAsync(ProjectDTO model);
    }
}
