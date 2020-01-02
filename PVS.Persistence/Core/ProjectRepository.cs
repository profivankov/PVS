using PVS.Entities;
using PVS.Persistance.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVS.Persistence.Core
{
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        public ProjectRepository(PVSContext dbContext) : base(dbContext)
        { }
    }
}
