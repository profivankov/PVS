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
    [Route("api/users/authenticate")]
    [ApiController]
    public class AuthenticationController : ApiController
    {
        private readonly IUserService _userService;

        public AuthenticationController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost]
        public AuthenticatedUser Authenticate([FromBody] UserDTO model)
        {
            var query = _userService.FindAsync(model);
            if (query != null)
            {
                return new AuthenticatedUser
                {
                    Id = query.Id,
                    FirstName = query.FirstName,
                    LastName = query.LastName,
                    Email = query.Email,
                    Password = query.Password,
                    AuthToken = "AuthTokenBruh"
                };
            }
            else
            {
                return null;
            }
        }

    }
}
