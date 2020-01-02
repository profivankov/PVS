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
    [Route("users")]
    [ApiController]
    public class HomeController : ApiController
    {
        private readonly IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
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
    }
}
