using PVS.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace PVS.Contracts.DTO
{
    public static class ProjectTaskExtension
    {
        public static ProjectTaskDTO ToModel(this ProjectTask entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new ProjectTaskDTO
            {
                Id = entity.Id,
                ProjectId = entity.ProjectId,
                TaskFatherId = entity.TaskFatherId,
                TaskName = entity.TaskName
            };
        }
    }
    public class ProjectTaskDTO
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public Guid TaskFatherId { get; set; }

        [Required]
        [StringLength(100)]
        public string TaskName { get; set; }
    }

}
