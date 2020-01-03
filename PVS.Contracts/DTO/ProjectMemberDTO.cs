using PVS.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace PVS.Contracts.DTO
{
    public static class ProjectMemberExtension
    {
        public static ProjectMemberDTO ToModel(this ProjectMember entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new ProjectMemberDTO
            {
                ProjectId = entity.ProjectId,
                UserId = entity.UserId,
                Role = entity.Role,
                JoinDate = entity.JoinDate
            };
        }
    }
    public class ProjectMemberDTO
    {
        public Guid ProjectId { get; set; }
        public Guid UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string Role { get; set; }

        public DateTime JoinDate { get; set; }

    }

}
