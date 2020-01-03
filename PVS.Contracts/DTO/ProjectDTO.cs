using PVS.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace PVS.Contracts.DTO
{
    public static class ProjectExtension
    {
        public static ProjectDTO ToModel(this Project entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new ProjectDTO
            {
                Id = entity.Id,
                UserId = entity.UserId,
                ProjectName = entity.ProjectName,
                Description = entity.Description
            };
        }
    }
    public class ProjectDTO
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        [Required]
        [StringLength(100)]
        public string ProjectName { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }

    }

}
