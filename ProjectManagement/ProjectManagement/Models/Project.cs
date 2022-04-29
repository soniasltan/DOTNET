﻿using System;
using System.Collections.Generic;

namespace ProjectManagement.Models
{
    public partial class Project
    {
        public int Id { get; set; }
        public string ProjectName { get; set; } = null!;
        public string ProjectDescription { get; set; } = null!;
        public int? ClientId { get; set; }
        public int? ProjectManagerId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? Status { get; set; }
    }
}
