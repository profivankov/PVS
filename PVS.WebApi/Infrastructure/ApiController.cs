using Microsoft.AspNetCore.Mvc;
using PVS.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PVS.WebApi.Infrastructure
{
    [ApiController]
    public class ApiController : ControllerBase
    {
        public static BaseModel IdResponse(Guid id)
        {
            return new BaseModel
            {
                Id = id
            };
        }

    }
}
