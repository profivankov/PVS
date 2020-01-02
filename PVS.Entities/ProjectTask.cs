using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PVS.Entities
{
    public class ProjectTask
    {
        [Key]
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public string TaskName { get; set; }
        public Guid TaskFatherId { get; set; }

        public virtual Project Project { get; set; }
    }
}
