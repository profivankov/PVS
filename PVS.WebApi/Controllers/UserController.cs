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
    [Route("api/users")]
    [ApiController]
    public class UserController : ApiController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<UserDTO> GetAsync(Guid id)
        {
            var user = await _userService.GetAsync(id);
            return user;
        }

        [HttpGet]
        public async Task<IEnumerable<UserDTO>> GetAllAsync()
        {
            var userList = await _userService.GetAllAsync();
            return userList;
        }

        [HttpPost]
        public async Task<BaseModel> CreateAsync([FromBody] UserDTO model)
        {
            if (!TryValidateModel(model))
            {
                throw new Exception("400");
            }

            var id = await _userService.CreateAsync(model);
            return IdResponse(id);
        }

        [HttpDelete("{id}")]
        public Task DeleteAsync(Guid id)
        {
            return _userService.DeleteAsync(id);
        }

        [HttpPut]
        public async Task<UserDTO> EditAsync([FromBody] UserDTO model)
        {
            if (!TryValidateModel(model))
            {
                throw new Exception("400");
            }

            return await _userService.EditAsync(model);
        }
    }
}
