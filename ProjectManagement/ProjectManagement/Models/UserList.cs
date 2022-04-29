using System;
using System.Collections.Generic;

namespace ProjectManagement.Models
{
    public partial class UserList
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int? UserRolesId { get; set; }
    }
}
