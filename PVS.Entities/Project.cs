using System;
using System.Collections.Generic;
using System.Text;

namespace PVS.Entities
{
    public class Project
    {
        public Guid Id { get; set; }
        public Guid VadovasId { get; set; }

        public User User { get; set; }

    }
}
