using System;
using System.Collections.Generic;

namespace ProjectManagement.Models
{
    public partial class UserDetail
    {
        public int Id { get; set; }
        public int? UserListId { get; set; }
        public string? Email { get; set; }
        public string? Phonenumber { get; set; }
        public string? Address { get; set; }
    }
}
