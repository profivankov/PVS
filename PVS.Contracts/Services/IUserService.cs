using PVS.Contracts.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PVS.Contracts.Services
{
    public interface IUserService
    {
        Task<UserDTO> GetAsync(Guid id);
        Task<IEnumerable<UserDTO>> GetAllAsync();
        Task<Guid> CreateAsync(UserDTO model);
        Task DeleteAsync(Guid id);
        Task<UserDTO> EditAsync(UserDTO model);
    }
}
