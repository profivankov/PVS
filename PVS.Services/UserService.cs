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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDTO> GetAsync(Guid id)
        {
            var entity = await _userRepository.GetByIdAsync(id);
            if (entity == null)
            {
                throw new Exception("User not found");
            }
            return entity.ToModel();
        }

        public async Task<IEnumerable<UserDTO>> GetAllAsync()
        {
            var query = await _userRepository.GetAllAsync();
            var model = query.Select(usr => usr.ToModel());
            return model;
        }

        public async Task<Guid> CreateAsync(UserDTO model)
        {
            var entity = new User()
            {
                Id = Guid.NewGuid(),
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email
            };

            await _userRepository.InsertAsync(entity);
            await _userRepository.SaveAsync();
            return entity.Id;
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _userRepository.GetByIdAsync(id);
            if (entity == null)
            {
                throw new Exception("User not found");
            }
            _userRepository.Delete(entity);
            await _userRepository.SaveAsync();
        }

        public async Task<UserDTO> EditAsync(UserDTO model)
        {
            var entity = await _userRepository.GetByIdAsync(model.Id);
            if (entity == null)
            {
                throw new Exception("User not found");
            }

            entity.FirstName = model.FirstName;
            entity.LastName = model.LastName;
            entity.Email = model.Email;
            _userRepository.Update(entity);
            await _userRepository.SaveAsync();

            return entity.ToModel();
        }
    }
}
