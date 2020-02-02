using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PVS.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}
