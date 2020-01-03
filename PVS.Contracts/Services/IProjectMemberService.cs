using PVS.Contracts.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PVS.Contracts.Services
{
    public interface IProjectMemberService
    {
        Task<ProjectMemberDTO> GetAsync(Guid id);
        Task<IEnumerable<ProjectMemberDTO>> GetAllAsync();
        Task<Guid> CreateAsync(ProjectMemberDTO model);
        Task DeleteAsync(Guid id);
        Task<ProjectMemberDTO> EditAsync(ProjectMemberDTO model);
    }
}
