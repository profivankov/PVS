using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PVS.Entities
{
    public class Project
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }

        public User User { get; set; }
        public virtual ICollection<ProjectMember> ProjectMembers { get; set; }
        public virtual ICollection<ProjectTask> ProjectTasks { get; set; }

    }
}
