using PVS.Entities;
using PVS.Persistance.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PVS.Persistence.Core
{
    public class ProjectTaskRepository : GenericRepository<ProjectTask>, IProjectTaskRepository
    {
        public ProjectTaskRepository(PVSContext dbContext) : base(dbContext)
        { }
    }
}
