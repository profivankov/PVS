using PVS.Entities;
using PVS.Persistance.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVS.Persistence.Core
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(PVSContext dbContext) : base(dbContext)
        { }
    }
}
