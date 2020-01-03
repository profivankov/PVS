using PVS.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace PVS.Contracts.DTO
{
    public static class UserExtension
    {
        public static UserDTO ToModel(this User entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new UserDTO
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Email = entity.Email,
                Password = entity.Password
            };
        }
    }
    public class UserDTO
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
