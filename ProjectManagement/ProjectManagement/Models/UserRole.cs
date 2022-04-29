using System;
using System.Collections.Generic;

namespace ProjectManagement.Models
{
    public partial class UserRole
    {
        public int Id { get; set; }
        public string Role { get; set; } = null!;
    }
}
